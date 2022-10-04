using AddressBookAPI.Entities.DataSets;
using AddressBookAPI.Helpers.Responses;
using AddressBookAPI.Services.Repositories;
using System;

namespace AddressBookAPI.Services
{
    public class RefTermService : IRefTermService
    {
        private readonly IRefSetRepository _refSetRepository;
        private readonly IRefSetMappingRepository _refSetMappingRepository;
        private readonly IRefTermRepository _refTermRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RefTermService(
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

        public RefTermResponse CreateRefTerm(RefTerm refTermData, Guid refSetId)
        {

            var refSet = _refSetRepository.GetRefSet(refSetId);

            if (refSet == null)
                return new RefTermResponse(false, "Refset does not exists", null);

            var refTerm = _refTermRepository.GetRefTerm(refTermData.Key);

            if (refTerm != null)
            {
                var RefTerms = _refSetMappingRepository.GetRefTermsByRefSetId(refSetId);
                foreach (var RefTerm in RefTerms)
                {
                    if (RefTerm.Key.ToLower() == refTermData.Key.ToLower())
                        return new RefTermResponse(false, "RefTerm already exists", null);
                }
                return new RefTermResponse(true, null, refTerm);
            }

            _refTermRepository.AddRefTerm(refTermData);
            _unitOfWork.Save();

            return new RefTermResponse(true, null, refTermData);
        }

        public void AddRefTermMapping(Guid refTermId,Guid refSetId)
        {
            var refSetMapping = new RefSetMapping {
                RefTermId = refTermId,
                RefSetId = refSetId
            };
            
            _refSetMappingRepository.AddRefSetMapping(refSetMapping);
            _unitOfWork.Save();
        }

        public RefTermResponse GetRefTermByName(string key)
        {

            var refTerm = _refTermRepository.GetRefTerm(key);

            if (refTerm == null)
                return new RefTermResponse(false, "RefTerm does not exists", null);

            return new RefTermResponse(true, null, refTerm);
        }

        public RefTermResponse GetRefTermById(Guid refTermId)
        {

            var refTerm = _refTermRepository.GetRefTerm(refTermId);

            if (refTerm == null)
                return new RefTermResponse(false, "RefTerm does not exists", null);

            return new RefTermResponse(true, null, refTerm);
        }

    }
}
