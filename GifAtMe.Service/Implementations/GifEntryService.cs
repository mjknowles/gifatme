using GifAtMe.Common.Domain;
using GifAtMe.Common.UnitOfWork;
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
        private readonly IGifEntryRepository _gifEntryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GifEntryService(IGifEntryRepository gifEntryRepository, IUnitOfWork unitOfWork)
        {
            if (gifEntryRepository == null) throw new ArgumentNullException("GifEntry Repo");
            if (unitOfWork == null) throw new ArgumentNullException("Unit of work");
            _gifEntryRepository = gifEntryRepository;
            _unitOfWork = unitOfWork;
        }

        public GetGifEntryResponse GetGifEntry(GetGifEntryRequest getGifEntryRequest)
        {
            GetGifEntryResponse getGifEntryResponse = new GetGifEntryResponse();
            GifEntry gifEntry = null;
            try
            {
                if (getGifEntryRequest.Id > 0)
                {
                    gifEntry = _gifEntryRepository.FindById(getGifEntryRequest.Id);
                }
                else
                {
                    if (getGifEntryRequest.UserIdSource.Equals(Constants.SlackIdSource))
                    {
                        gifEntry = _gifEntryRepository.FindByNonIdFieldsAndSlackUserId(getGifEntryRequest.UserId, getGifEntryRequest.Keyword, getGifEntryRequest.AlternateIndex - 1);
                    }
                    else
                    {
                        gifEntry = _gifEntryRepository.FindByNonIdFieldsAndAppId(getGifEntryRequest.UserId, getGifEntryRequest.Keyword, getGifEntryRequest.AlternateIndex - 1);
                    }
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
                if (String.IsNullOrEmpty(getAllGifEntriesRequest.UserId))
                {
                    allGifEntries = _gifEntryRepository.GetAllForAllUserIds();
                }
                else
                {
                    if (String.IsNullOrEmpty(getAllGifEntriesRequest.Keyword))
                    {
                        allGifEntries = _gifEntryRepository.GetAllForUserId(getAllGifEntriesRequest.UserId);
                    }
                    else
                    {
                        allGifEntries = _gifEntryRepository.GetAllForUserIdAndKeyword(getAllGifEntriesRequest.UserId, getAllGifEntriesRequest.Keyword);
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
                _gifEntryRepository.Insert(newGifEntry);
                return new InsertGifEntryResponse();
            }
            catch (Exception ex)
            {
                return new InsertGifEntryResponse() { Exception = ex };
            }
        }

        /*
        public UpdateGifEntryResponse UpdateGifEntry(UpdateGifEntryRequest updateGifEntryRequest)
        {
            try
            {
                GifEntry existingGifEntry = null;
                if (updateGifEntryRequest.Id > 0)
                {
                    existingGifEntry = _gifEntryRepository.FindById(updateGifEntryRequest.Id);
                }
                else
                {
                    existingGifEntry = _gifEntryRepository.FindByNonIdFields(updateGifEntryRequest.UserId, updateGifEntryRequest.Keyword, updateGifEntryRequest.AlternateIndex - 1);
                }
                if (existingGifEntry != null)
                {
                    GifEntry assignableProperties = AssignAvailablePropertiesToDomain(updateGifEntryRequest.GifEntryProperties);
                    existingGifEntry.Keyword = assignableProperties.Keyword;
                    existingGifEntry.Url = assignableProperties.Url;
                    existingGifEntry.UserId = assignableProperties.UserId;
                    ThrowExceptionIfGifEntryIsInvalid(existingGifEntry);
                    _gifEntryRepository.Update(existingGifEntry);
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
                    existingGifEntry = _gifEntryRepository.FindById(deleteGifEntryRequest.Id);
                }
                else
                {
                    existingGifEntry = _gifEntryRepository.FindByNonIdFields(deleteGifEntryRequest.UserId, deleteGifEntryRequest.Keyword, deleteGifEntryRequest.AlternateIndex - 1);
                }
                if (existingGifEntry != null)
                {
                    _gifEntryRepository.Delete(existingGifEntry);
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
         * */

        private ResourceNotFoundException GetStandardGifEntryNotFoundException()
        {
            return new ResourceNotFoundException("The requested gif entry was not found.");
        }

        private GifEntry AssignAvailablePropertiesToDomain(GifEntryDTOProperties gifEntryProperties)
        {
            GifEntry gifEntry = new GifEntry();
            gifEntry.Keyword = gifEntryProperties.Keyword;
            gifEntry.Url = gifEntryProperties.Url;
            gifEntry.UserId = gifEntryProperties.UserId;

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