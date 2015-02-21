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
using System.Threading.Tasks;

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

        public GetGifEntryResponse GetGifEntryById(GetGifEntryByIdRequest getGifEntryByIdRequest)
        {
            GetGifEntryResponse getGifEntryResponse = new GetGifEntryResponse();
            GifEntry gifEntry = null;
            try
            {
                gifEntry = _gifEntryRepoAccessor.FindById(getGifEntryByIdRequest.Id);
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

        public GetGifEntryResponse GetGifEntryByNonId(GetGifEntryByNonIdRequest getGifEntryByNonIdRequest)
        {
            GetGifEntryResponse getGifEntryResponse = new GetGifEntryResponse();
            GifEntry gifEntry = null;
            try
            {
                gifEntry = _gifEntryRepoAccessor.FindByNonIdFields(getGifEntryByNonIdRequest.UserName, getGifEntryByNonIdRequest.Keyword, getGifEntryByNonIdRequest.AlternateIndex);
                if(gifEntry == null)
                {
                    getGifEntryResponse.Exception = GetStandardGifEntryNotFoundException();
                }
                else
                {
                    getGifEntryResponse.GifEntry = gifEntry.ConvertToDTO();
                }
            }
            catch(Exception ex)
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
                // Use the service layer to sort in appropriate ordering for outside applications
                allGifEntries = _gifEntryRepoAccessor.GetAllByUserNameAndKeyword(getAllGifEntriesRequest.UserName, getAllGifEntriesRequest.Keyword).OrderBy(g => g.Id);
                getGifEntriesResponse.GifEntries = allGifEntries.ConvertToDTO();
            }
            catch (Exception ex)
            {
                getGifEntriesResponse.Exception = ex;
            }
            return getGifEntriesResponse;
        }

        public InsertGifEntryResponse InsertGifEntry(InsertGifEntryRequest insertGifEntryRequest)
        {
            GifEntry newGifEntry = AssignAvailablePropertiesToDomain(insertGifEntryRequest.GifEntryProperties);
            ThrowExceptionIfGifEntryIsInvalid(newGifEntry);
            try
            {
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
                GifEntry existingGifEntry = _gifEntryRepoAccessor.FindById(updateGifEntryRequest.Id);
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
                GifEntry gifEntry = _gifEntryRepoAccessor.FindById(deleteGifEntryRequest.Id);
                if (gifEntry != null)
                {
                    _gifEntryRepoAccessor.Delete(gifEntry);
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

        private GifEntry AssignAvailablePropertiesToDomain(GifEntryPropertiesDTO gifEntryProperties)
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
