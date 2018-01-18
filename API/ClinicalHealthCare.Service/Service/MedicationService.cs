using ClinicalHealthCare.Repository.IRepository;
using ClinicalHealthCare.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicalHealthCare.Entities.Response;
using System.Net.Http;
using ClinicalHealthCare.Entities.Request;

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

        public async Task<SingleMedicationResponse> GetMedicationDetailsById(int id)
        {
            return await _IMedicationRepository.GetMedicationDetailsById(id);
        }

        public async Task<BaseResponse> SaveMedication(MedicationRequest medicationRequest)
        {
            return await _IMedicationRepository.SaveMedication(medicationRequest);
        }

        public async Task<SearchMedicationListResponse> SearchMedication(string keyword)
        {
            return await _IMedicationRepository.SearchMedication(keyword);
        }
        

        #endregion
    }
}
