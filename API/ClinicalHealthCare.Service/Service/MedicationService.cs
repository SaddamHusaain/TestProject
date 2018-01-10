using ClinicalHealthCare.Repository.IRepository;
using ClinicalHealthCare.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicalHealthCare.Entities.Response;

namespace ClinicalHealthCare.Service.Service
{
    public class MedicationService: IMedicationService
    {
        #region Private

        private IMedicationRepository _IMedicationRepository;

        #endregion

        public MedicationService(IMedicationRepository IMedicationRepository)
        {
            _IMedicationRepository = IMedicationRepository;
        }

        #region public

        public async Task<MedicationListResponse> GetAllMedicationDetails()
        {
            return await _IMedicationRepository.GetAllMedicationDetails();
        }

        #endregion
    }
}
