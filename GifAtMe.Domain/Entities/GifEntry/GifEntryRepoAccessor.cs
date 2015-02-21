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
        /// If AlternateIndex does not exist, then select a random
        /// gif from the same keyword
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="keyword"></param>
        /// <param name="alternateIndex"></param>
        /// <returns></returns>
        public GifEntry FindByNonIdFields(string userName, string keyword, int? alternateIndex)
        {
            if (!(alternateIndex.HasValue))
            {
                // If user doesn't want a specific gif from their alternates for the chosen keyword, select a random one for them
                // Random.Next() is exclusive of the upper bound
                IEnumerable<GifEntry> totalUserGifsForKeyword = _gifEntryRepository.GetAllForUserNameAndKeyword(userName, keyword);
                int rand = new Random().Next(totalUserGifsForKeyword.Count());
                return totalUserGifsForKeyword.ElementAtOrDefault(rand);
            }
            GifEntry gif = _gifEntryRepository.GetGifEntryForUserNameAndKeywordAndAlternateIndex(userName, keyword, alternateIndex.Value);

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

        public void Insert(GifEntry gifEntry)
        {
            _gifEntryRepository.Insert(gifEntry);
            _unitOfWork.Commit();
        }

        public void Update(GifEntry gifEntry)
        {
            _gifEntryRepository.Update(gifEntry);
            _unitOfWork.Commit();
        }

        public void Delete(GifEntry gifEntry)
        {
            _gifEntryRepository.Delete(gifEntry);
            _unitOfWork.Commit();
        }
    }
}
