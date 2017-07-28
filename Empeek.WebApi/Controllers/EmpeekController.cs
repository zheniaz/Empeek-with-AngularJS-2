using Empeek.WebApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Empeek.WebApi.Controllers
{
    public class EmpeekController : BaseAPIController
    {
        private static SearchingFilesAndDirectories _searchingFilesAndDirectories = SearchingFilesAndDirectories.Current;

        [Route(@"{path=D:\}")]
        [HttpGet]
        public HttpResponseMessage GetNewEntities(string path)
        {
            if (!Directory.Exists(path))
            {
                path = @"D:\";
            }
            empeek = _searchingFilesAndDirectories.Set(path);
            return ToJson(empeek);
        }
    }
}