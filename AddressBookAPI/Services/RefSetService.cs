using AddressBookAPI.Entities.DataSets;
using AddressBookAPI.Helpers.Responses;
using AddressBookAPI.Services.Repositories;
using System;
using System.Linq;

namespace AddressBookAPI.Services
{
    public class RefSetService : IRefSetService
    {
        private readonly IRefSetRepository _refSetRepository;
        private readonly IRefSetMappingRepository _refSetMappingRepository;
        private readonly IRefTermRepository _refTermRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RefSetService(
            IRefSetRepository refSetRepository,
            IRefSetMappingRepository refSetMappingRepository,
            IRefTermRepository refTermRepository,
            IUnitOfWork unitOfWork)
        {
            _refSetRepository = refSetRepository;
            _refSetMappingRepository = refSetMappingRepository;
            _refTermRepository = refTermRepository;
            _unitOfWork = unitOfWork;
        }

        public RefSetResponse CreateRefSet(RefSet refSetData)
        {
            var refSet = _refSetRepository.GetRefSet(refSetData.Set);

            if (refSet != null)
                return new RefSetResponse(false, "Ref Set already exists", null);

            _refSetRepository.AddRefSet(refSetData);
            _unitOfWork.Save();

            return new RefSetResponse(true, null, refSetData);
        }

        public RefSetResponse GetRefSetByName(string set)
        {
            
            var refSet = _refSetRepository.GetRefSet(set);

            if(refSet == null)
                return new RefSetResponse(false,"Refset does not exists",null);

            return new RefSetResponse(true, null, refSet);
        }

        public RefSetResponse GetRefSetById(Guid setId)
        {

            var refSet = _refSetRepository.GetRefSet(setId);

            if (refSet == null)
                return new RefSetResponse(false, "Refset does not exists", null);

            return new RefSetResponse(true, null, refSet);
        }

        public RefTermListResponse GetRefTermsByRefSetId(Guid setId) {

            var refSet = _refSetRepository.GetRefSet(setId);

            if (refSet == null)
                return new RefTermListResponse(false, "Refset does not exists", null);

            var refTerms = _refSetMappingRepository.GetRefTermsByRefSetId(setId);

            int count = refTerms.Count();
            if(count == 0)
            {
                return new RefTermListResponse(false, $"There are no RefTerms under ref set Id: {setId}", null);
            }

            return new RefTermListResponse(true, null, refTerms);
        }

        public RefSetResponse DeleteRefSetById(Guid setId)
        {

            var refSet = _refSetRepository.GetRefSet(setId);

            if (refSet == null)
                return new RefSetResponse(false, "Refset does not exists", null);

            _refSetRepository.DeleteRefSet(refSet);
            _unitOfWork.Save();

            return new RefSetResponse(true, null, refSet);
        }

    }
}
