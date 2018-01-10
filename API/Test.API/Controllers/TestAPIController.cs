using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Test.Service.IService;

namespace Test.API.Controllers
{
    [RoutePrefix("TestAPI")]
    public class TestAPIController : ApiController
    {
        #region Private

        private ITestService _ITestService = null;
        private System.Net.Http.HttpResponseMessage httpResponseMessage = null;

        #endregion

        public TestAPIController(ITestService ITestService)
        {
            _ITestService = ITestService;
        }

        [HttpGet]
        [Route("Test")]
        [ActionName("Test")]
        public HttpResponseMessage Test()
        {
            httpResponseMessage = new HttpResponseMessage();
            _ITestService.Test();
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, "Success");

            return httpResponseMessage;
        }
    }
}
