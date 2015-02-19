using GifAtMe.Common.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifAtMe.Domain.Entities.GifEntry
{
    public class GifEntryRepoAccessor : IGifEntryRepoAccessor
    {
        private readonly IGifEntryRepository _gifEntryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GifEntryRepoAccessor(IGifEntryRepository gifEntryRepository, IUnitOfWork unitOfWork)
        {
            if (gifEntryRepository == null) throw new ArgumentNullException("GifEntry Repo");
            if (unitOfWork == null) throw new ArgumentNullException("Unit of work");
            _gifEntryRepository = gifEntryRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Standard get by id
        /// </summary>
        /// <param name="id">id of the requested gif entry</param>
        /// <returns></returns>
        public GifEntry FindById(int id)
        {
            return _gifEntryRepository.FindById(id);
        }

        /// <summary>
        /// If alternateId does not exist, then select a random
        /// gif from the same keyword
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="keyword"></param>
        /// <param name="alternateId"></param>
        /// <returns></returns>
        public GifEntry FindByNonIdFields(string userName, string keyword, int? alternateId)
        {
            GifEntry gif;
            if (!(alternateId.HasValue))
            {
                // If user doesn't want a specific gif from their alternates for the chosen keyword, select a random one for them
                IEnumerable<GifEntry> totalUserGifsForKeyword = _gifEntryRepository.GetAllForUserNameAndKeyword(userName, keyword);
                int rand = new Random().Next(totalUserGifsForKeyword.Count());

                gif = totalUserGifsForKeyword.Skip(rand).First();
            }
            else
            {
                // If alternate ID is present select the appropriate one
                gif = _gifEntryRepository.GetByNonIdFields(userName, keyword, alternateId.Value);
            }
            return gif;
        }

        public IEnumerable<GifEntry> GetAllByUserNameAndKeyword(string userName, string keyword)
        {
            if(String.IsNullOrEmpty(userName))
            {
                return _gifEntryRepository.GetAllForUserName(userName);
            }
            return _gifEntryRepository.GetAllForUserNameAndKeyword(userName, keyword);
        }

    }
}
