using GifAtMe.Common.Domain;
using GifAtMe.Domain.Entities.GifEntry;
using GifAtMe.Service.DTOs;
using GifAtMe.Service.Exceptions;
using GifAtMe.Service.Interfaces;
using GifAtMe.Service.Messaging.GifEntries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GifAtMe.Service.Implementations
{
    public class GifEntryService : IGifEntryService
    {
        private readonly IGifEntryRepoAccessor _gifEntryRepoAccessor;

        public GifEntryService(IGifEntryRepoAccessor gifEntryRepoAccessor)
        {
            if (gifEntryRepoAccessor == null) throw new ArgumentNullException("GifEntry Repo Accessor");
            _gifEntryRepoAccessor = gifEntryRepoAccessor;
        }

        public GetGifEntryResponse GetGifEntry(GetGifEntryRequest getGifEntryRequest)
        {
            GetGifEntryResponse getGifEntryResponse = new GetGifEntryResponse();
            GifEntry gifEntry = null;
            try
            {
                if (getGifEntryRequest.Id > 0)
                {
                    gifEntry = _gifEntryRepoAccessor.FindById(getGifEntryRequest.Id);
                }
                else
                {
                    gifEntry = _gifEntryRepoAccessor.FindByNonIdFields(getGifEntryRequest.UserName, getGifEntryRequest.Keyword, getGifEntryRequest.AlternateIndex - 1);
                }
                if (gifEntry == null)
                {
                    getGifEntryResponse.Exception = GetStandardGifEntryNotFoundException();
                }
                else
                {
                    getGifEntryResponse.GifEntry = gifEntry.ConvertToDTO();
                }
            }
            catch (Exception ex)
            {
                getGifEntryResponse.Exception = ex;
            }

            return getGifEntryResponse;
        }

        public GetGifEntriesResponse GetAllGifEntries(GetAllGifEntriesRequest getAllGifEntriesRequest)
        {
            GetGifEntriesResponse getGifEntriesResponse = new GetGifEntriesResponse();
            IEnumerable<GifEntry> allGifEntries = null;

            try
            {
                if (String.IsNullOrEmpty(getAllGifEntriesRequest.UserName))
                {
                    allGifEntries = _gifEntryRepoAccessor.GetAll();
                }
                else
                {
                    if (String.IsNullOrEmpty(getAllGifEntriesRequest.Keyword))
                    {
                        allGifEntries = _gifEntryRepoAccessor.GetAllForUserName(getAllGifEntriesRequest.UserName);
                    }
                    else
                    {
                        allGifEntries = _gifEntryRepoAccessor.GetAllForUserNameAndKeyword(getAllGifEntriesRequest.UserName, getAllGifEntriesRequest.Keyword);
                    }
                }
                // Use the service layer to sort in appropriate ordering for outside applications
                getGifEntriesResponse.GifEntries = allGifEntries.ConvertToDTO().OrderBy(g => g.Keyword).ThenByDescending(g => g.AlternateIndex);
            }
            catch (Exception ex)
            {
                getGifEntriesResponse.Exception = ex;
            }
            return getGifEntriesResponse;
        }

        public InsertGifEntryResponse InsertGifEntry(InsertGifEntryRequest insertGifEntryRequest)
        {
            GifEntry newGifEntry = AssignAvailablePropertiesToDomain(insertGifEntryRequest.GifEntryDTOProperties);
            try
            {
                ThrowExceptionIfGifEntryIsInvalid(newGifEntry);
                _gifEntryRepoAccessor.Insert(newGifEntry);
                return new InsertGifEntryResponse();
            }
            catch (Exception ex)
            {
                return new InsertGifEntryResponse() { Exception = ex };
            }
        }

        public UpdateGifEntryResponse UpdateGifEntry(UpdateGifEntryRequest updateGifEntryRequest)
        {
            try
            {
                GifEntry existingGifEntry = null;
                if (updateGifEntryRequest.Id > 0)
                {
                    existingGifEntry = _gifEntryRepoAccessor.FindById(updateGifEntryRequest.Id);
                }
                else
                {
                    existingGifEntry = _gifEntryRepoAccessor.FindByNonIdFields(updateGifEntryRequest.UserName, updateGifEntryRequest.Keyword, updateGifEntryRequest.AlternateIndex - 1);
                }
                if (existingGifEntry != null)
                {
                    GifEntry assignableProperties = AssignAvailablePropertiesToDomain(updateGifEntryRequest.GifEntryProperties);
                    existingGifEntry.Keyword = assignableProperties.Keyword;
                    existingGifEntry.Url = assignableProperties.Url;
                    existingGifEntry.UserName = assignableProperties.UserName;
                    ThrowExceptionIfGifEntryIsInvalid(existingGifEntry);
                    _gifEntryRepoAccessor.Update(existingGifEntry);
                    return new UpdateGifEntryResponse();
                }
                else
                {
                    return new UpdateGifEntryResponse() { Exception = GetStandardGifEntryNotFoundException() };
                }
            }
            catch (Exception ex)
            {
                return new UpdateGifEntryResponse() { Exception = ex };
            }
        }

        public DeleteGifEntryResponse DeleteGifEntry(DeleteGifEntryRequest deleteGifEntryRequest)
        {
            try
            {
                GifEntry existingGifEntry = null;
                if (deleteGifEntryRequest.Id > 0)
                {
                    existingGifEntry = _gifEntryRepoAccessor.FindById(deleteGifEntryRequest.Id);
                }
                else
                {
                    existingGifEntry = _gifEntryRepoAccessor.FindByNonIdFields(deleteGifEntryRequest.UserName, deleteGifEntryRequest.Keyword, deleteGifEntryRequest.AlternateIndex - 1);
                }
                if (existingGifEntry != null)
                {
                    _gifEntryRepoAccessor.Delete(existingGifEntry);
                    return new DeleteGifEntryResponse();
                }
                else
                {
                    return new DeleteGifEntryResponse() { Exception = GetStandardGifEntryNotFoundException() };
                }
            }
            catch (Exception ex)
            {
                return new DeleteGifEntryResponse() { Exception = ex };
            }
        }

        private ResourceNotFoundException GetStandardGifEntryNotFoundException()
        {
            return new ResourceNotFoundException("The requested gif entry was not found.");
        }

        private GifEntry AssignAvailablePropertiesToDomain(GifEntryDTOProperties gifEntryProperties)
        {
            GifEntry gifEntry = new GifEntry();
            gifEntry.Keyword = gifEntryProperties.Keyword;
            gifEntry.Url = gifEntryProperties.Url;
            gifEntry.UserName = gifEntryProperties.UserName;

            return gifEntry;
        }

        private void ThrowExceptionIfGifEntryIsInvalid(GifEntry gifEntry)
        {
            IEnumerable<BusinessRule> brokenRules = gifEntry.GetBrokenRules();
            if (brokenRules.Count() > 0)
            {
                StringBuilder brokenRulesBuilder = new StringBuilder();
                brokenRulesBuilder.AppendLine("There were problems saving the GifAtMe GifEntry object:");
                foreach (BusinessRule businessRule in brokenRules)
                {
                    brokenRulesBuilder.AppendLine(businessRule.RuleDescription);
                }

                throw new Exception(brokenRulesBuilder.ToString());
            }
        }
    }
}