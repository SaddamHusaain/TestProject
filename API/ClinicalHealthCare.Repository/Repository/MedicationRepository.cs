using ClinicalHealthCare.Entities.Common;
using ClinicalHealthCare.Entities.Request;
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
    public class MedicationRepository : IMedicationRepository
    {
        #region Private 

        private BaseResponse _BaseResponse = null;
        private MedicationListResponse _MedicationListResponse = null;
        private SearchMedicationListResponse _SearchMedicationListResponse = null;
        private SingleMedicationResponse _SingleMedicationResponse = null;

        #endregion


        #region pubic

        public async Task<MedicationListResponse> GetAllMedicationDetails()
        {
            try
            {
                _MedicationListResponse = new MedicationListResponse();
                using (ClinicalHealthCareEntities db = new ClinicalHealthCareEntities())
                {
                    _MedicationListResponse.MedicationList = await db.Medications.Select(x => new MedicationResponse
                    {
                        MedicationId = x.MedicationId,
                        Name = x.Name,
                        Quantity = x.Quantity,
                        Dosage = x.Dosage,
                        Unit = x.Unit,
                        Form = x.Form,
                        Method = x.Method,
                        Indication = x.Indication,
                        Duration = x.Duration,
                        StartDate = x.StartDate,
                        EndDate = x.EndDate,
                        Frequency = x.Frequency,
                        Notes = x.Notes,
                        Prescriber = x.Prescriber,
                        RXNumber = x.RXNumber,
                        Active = x.Active,
                        CreatedDate = x.CreatedDate
                    }).OrderByDescending(x => x.CreatedDate).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                _MedicationListResponse.Success = false;
                _MedicationListResponse.Message = ex.Message;
            }
            return _MedicationListResponse;
        }

        public async Task<SingleMedicationResponse> GetMedicationDetailsById(int id)
        {
            try
            {
                _SingleMedicationResponse = new SingleMedicationResponse();
                using (ClinicalHealthCareEntities db = new ClinicalHealthCareEntities())
                {
                    var MedicationDetail = await db.Medications.Where(x => x.MedicationId == id).Select(x => new MedicationResponse
                    {
                        MedicationId = x.MedicationId,
                        Name = x.Name,
                        CreatedDate = x.CreatedDate,
                        Dosage = x.Dosage,
                        Duration = x.Duration,
                        Quantity = x.Quantity,
                        StartDate = x.StartDate,
                        EndDate = x.EndDate,
                        Frequency = x.Frequency,
                        Active = x.Active,
                        Notes = x.Notes,
                        Prescriber = x.Prescriber,
                        RXNumber = x.RXNumber
                    }).OrderByDescending(x => x.CreatedDate).FirstOrDefaultAsync();

                    if (MedicationDetail != null)
                    {
                        _SingleMedicationResponse.medication = MedicationDetail;
                        _SingleMedicationResponse.Success = true;
                        _SingleMedicationResponse.Message = null;
                    }
                    else
                    {
                        _SingleMedicationResponse.medication = null;
                        _SingleMedicationResponse.Success = false;
                        _SingleMedicationResponse.Message = CustomErrorMessages.INVALID_MEDICATION_ID;
                    }
                }
            }
            catch (Exception ex)
            {
                _SingleMedicationResponse.Success = false;
                _SingleMedicationResponse.Message = ex.Message;
            }
            return _SingleMedicationResponse;
        }

        public async Task<BaseResponse> SaveMedication(MedicationRequest medicationRequest)
        {
            try
            {
                _BaseResponse = new BaseResponse();
                using (ClinicalHealthCareEntities db = new ClinicalHealthCareEntities())
                {
                    Medication Medication = new Medication();
                    Medication.Name = medicationRequest.Name;
                    Medication.Quantity = medicationRequest.Quantity;
                    Medication.Dosage = medicationRequest.Dosage;
                    Medication.Unit = medicationRequest.Unit;
                    Medication.Form = medicationRequest.Form;
                    Medication.Method = medicationRequest.Method;
                    Medication.Indication = medicationRequest.Indication;
                    Medication.Frequency = medicationRequest.Frequency;
                    Medication.Duration = medicationRequest.Duration;
                    Medication.StartDate = medicationRequest.StartDate;
                    Medication.EndDate = medicationRequest.EndDate;
                    Medication.Prescriber = medicationRequest.Prescriber;
                    Medication.RXNumber = medicationRequest.RXNumber;
                    Medication.Notes = medicationRequest.Notes;
                    Medication.Active = Convert.ToBoolean(medicationRequest.Active);
                    Medication.CreatedDate = DateTime.Now;

                    db.Medications.Add(Medication);
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _BaseResponse.Success = false;
                _BaseResponse.Message = ex.Message;
            }
            return _BaseResponse;
        }

        public async Task<SearchMedicationListResponse> SearchMedication(string keyword)
        {
            try
            {
                _SearchMedicationListResponse = new SearchMedicationListResponse();
                using (ClinicalHealthCareEntities db = new ClinicalHealthCareEntities())
                {
                    _SearchMedicationListResponse.SearchMedicationList = await db.Medications.Where(x => x.Name.Contains(keyword)).Select(x => new SearchMedicationResponse
                    {
                        id = x.MedicationId,
                        name = x.Name
                    }).ToListAsync();

                }
            }
            catch (Exception ex)
            {
                _SearchMedicationListResponse.Success = false;
                _SearchMedicationListResponse.Message = ex.Message;
            }
            return _SearchMedicationListResponse;
        }

        #endregion
    }
}
