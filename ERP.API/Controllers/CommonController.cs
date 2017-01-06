
using ERP.Common;
using ERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ERP.API.Infrastructure.Extensions;
namespace ERP.API.Controllers
{
    [RoutePrefix("api/Common")]
    public class CommonController : ApiController
    {
        ICommonApi _commonApi;
        public CommonController(ICommonApi commonApi)
        {
            this._commonApi = commonApi;
        }

        [HttpPost]
        public HttpResponseMessage WriteError([FromBody]ErrorLog objRequest)
        {
            if (objRequest == null)
            {
                var res = this.CreateBadRequestResponse("Requested object is null", "No error information provided.");
                throw new HttpResponseException(res);
            }
            objRequest = _commonApi.WriteLog(objRequest);
            return Request.CreateResponse(HttpStatusCode.OK, objRequest);
        }       
    }
}
