using ClinicalHealthCare.Entities.Response;
using ClinicalHealthCare.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalHealthCare.Repository.Repository
{
    public class MedicationRepository: IMedicationRepository
    {
        #region Private 

        private BaseResponse baseResponse = null;
        private MedicationListResponse _MedicationListResponse = null;

        #endregion


        #region pubic

        public async Task<MedicationListResponse> GetAllMedicationDetails()
        {
            try
            {
                _MedicationListResponse = new MedicationListResponse();
                using (ClinicalHealthCareEntities db = new ClinicalHealthCareEntities())
                {
                   _MedicationListResponse.MedicationList= await db.Medications.Select(x => new MedicationResponse { MedicationId = x.MedicationId,
                       Name = x.Name, CreatedDate = x.CreatedDate, Dosage = x.Dosage, StartDate = x.StartDate, EndDate = x.EndDate, Frequency = x.Frequency,
                       Active = x.Active, Notes = x.Notes, Prescriber = x.Prescriber, RXNumber = x.RXNumber }).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                _MedicationListResponse.Success = false;
                _MedicationListResponse.Message = ex.Message;
            }
            return _MedicationListResponse;
        }


        #endregion
    }
}
