using ClinicalHealthCare.Entities.Common;
using ClinicalHealthCare.Entities.Request;
using ClinicalHealthCare.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ClinicalHealthCare.API.Controllers
{
    [RoutePrefix("MedicationAPI")]
    public class MedicationAPIController : ApiController
    {
        #region Private

        private IMedicationService _IMedicationService = null;
        private System.Net.Http.HttpResponseMessage httpResponseMessage = null;

        #endregion

        public MedicationAPIController(IMedicationService IMedicationService)
        {
            _IMedicationService = IMedicationService;
        }

        [HttpGet]
        [Route("GetAllMedicationDetails")]
        [ActionName("GetAllMedicationDetails")]
        public async Task<HttpResponseMessage> GetAllMedicationDetails()
        {
            httpResponseMessage = new HttpResponseMessage();

            var getAllMedicationResponse = await _IMedicationService.GetAllMedicationDetails();
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, getAllMedicationResponse);
            return httpResponseMessage;
        }

        [HttpGet]
        [Route("GetMedicationDetailsById")]
        [ActionName("GetMedicationDetailsById")]
        public async Task<HttpResponseMessage> GetMedicationDetailsById(int id)
        {
            httpResponseMessage = new HttpResponseMessage();
            if (id > 0)
            {
                var getMedicationResponse = await _IMedicationService.GetMedicationDetailsById(id);
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, getMedicationResponse);
            }
            else
            {
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, new { Message = CustomErrorMessages.INVALID_INPUTS, Success = false });
            }
            return httpResponseMessage;
        }

        [HttpPost]
        [Route("SaveMedication")]
        [ActionName("SaveMedication")]
        public async Task<HttpResponseMessage> SaveMedication(MedicationRequest medicationRequest)
        {
            httpResponseMessage = new HttpResponseMessage();
            if (medicationRequest != null && ModelState.IsValid)
            {
                var saveMedication = await _IMedicationService.SaveMedication(medicationRequest);
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, saveMedication);
            }
            else
            {
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, new { Message = CustomErrorMessages.INVALID_INPUTS, Success = false });
            }
            return httpResponseMessage;
        }

        [HttpGet]
        [Route("SearchMedication")]
        [ActionName("SearchMedication")]
        public async Task<HttpResponseMessage> SearchMedication(string keyword)
        {
            if (keyword != null)
            {
                httpResponseMessage = new HttpResponseMessage();
                var SearchMedicationResponse = await _IMedicationService.SearchMedication(keyword);
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, SearchMedicationResponse);
            }
            else
            {
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, new { Message = CustomErrorMessages.INVALID_INPUTS, Success = false });
            }
            return httpResponseMessage;
        }
    }
}
