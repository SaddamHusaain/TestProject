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
    }
}
