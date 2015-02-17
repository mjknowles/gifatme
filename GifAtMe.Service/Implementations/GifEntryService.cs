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
        private readonly IGifEntryRepository _gifEntryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GifEntryService(IGifEntryRepository gifEntryRepository, IUnitOfWork unitOfWork)
        {
            if (gifEntryRepository == null) throw new ArgumentNullException("GifEntry Repo");
            if (unitOfWork == null) throw new ArgumentNullException("Unit of work");
            _gifEntryRepository = gifEntryRepository;
            _unitOfWork = unitOfWork;
        }

        public GetGifEntryResponse GetGifEntryById(GetGifEntryByIdRequest getGifEntryByIdRequest)
        {
            GetGifEntryResponse getGifEntryResponse = new GetGifEntryResponse();
            GifEntry gifEntry = null;
            try
            {
                gifEntry = _gifEntryRepository.FindById(getGifEntryByIdRequest.Id);
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
                gifEntry = _gifEntryRepository.GetByNonIdFields(getGifEntryByNonIdRequest.UserName, getGifEntryByNonIdRequest.Keyword, getGifEntryByNonIdRequest.AlternateId);
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
                allGifEntries = _gifEntryRepository.GetAllByUserName(getAllGifEntriesRequest.UserName);
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
                _gifEntryRepository.Insert(newGifEntry);
                _unitOfWork.Commit();
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
                GifEntry existingGifEntry = _gifEntryRepository.FindById(updateGifEntryRequest.Id);
                if (existingGifEntry != null)
                {
                    GifEntry assignableProperties = AssignAvailablePropertiesToDomain(updateGifEntryRequest.GifEntryProperties);
                    existingGifEntry.AlternateId = assignableProperties.AlternateId;
                    existingGifEntry.Keyword = assignableProperties.Keyword;
                    existingGifEntry.Url = assignableProperties.Url;
                    existingGifEntry.UserName = assignableProperties.UserName;
                    existingGifEntry.AlternateId = assignableProperties.AlternateId;
                    ThrowExceptionIfGifEntryIsInvalid(existingGifEntry);
                    _gifEntryRepository.Update(existingGifEntry);
                    _unitOfWork.Commit();
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
                GifEntry gifEntry = _gifEntryRepository.FindById(deleteGifEntryRequest.Id);
                if (gifEntry != null)
                {
                    _gifEntryRepository.Delete(gifEntry);
                    _unitOfWork.Commit();
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
            gifEntry.AlternateId = gifEntryProperties.AlternateId;

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
