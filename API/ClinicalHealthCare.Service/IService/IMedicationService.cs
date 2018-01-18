using ClinicalHealthCare.Entities.Request;
using ClinicalHealthCare.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalHealthCare.Service.IService
{
    public interface IMedicationService
    {
        Task<MedicationListResponse> GetAllMedicationDetails();

        Task<SingleMedicationResponse> GetMedicationDetailsById(int id);

        Task<BaseResponse> SaveMedication(MedicationRequest medicationRequest);

        Task<SearchMedicationListResponse> SearchMedication(string keyword);
    }
}
