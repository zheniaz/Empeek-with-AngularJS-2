using Empeek.WebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace Empeek.WebApi.Controllers
{
    public class BaseAPIController : ApiController
    {
        protected FilesAndDirsEntity empeek = new FilesAndDirsEntity();
        protected HttpResponseMessage ToJson(FilesAndDirsEntity obj)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            return response;
        }
    }
}