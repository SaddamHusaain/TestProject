using ClinicalHealthCare.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalHealthCare.Service.IService
{
    public interface IMedicationService
    {
        Task<MedicationListResponse> GetAllMedicationDetails();
    }
}
