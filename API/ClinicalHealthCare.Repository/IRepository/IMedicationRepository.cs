using ClinicalHealthCare.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalHealthCare.Repository.IRepository
{
    public interface IMedicationRepository
    {
        Task<MedicationListResponse> GetAllMedicationDetails();
    }
}
