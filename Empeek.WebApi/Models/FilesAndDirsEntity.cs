using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Empeek.WebApi.Models
{
    public class FilesAndDirsEntity
    {
        public int Less10Mb { get; set; }
        public int More10Less50Mb { get; set; }
        public int More50Less100Mb { get; set; }
        public int More100Mb { get; set; }
        public string CurrentPath { get; set; }
        public string BackPath { get; set; }

        public string ExceptionMessage { get; set; }
        public bool Exception { get; set; }
        public IEnumerable<string> DataDisk { get; set; }
        public IEnumerable<string> DataDir { get; set; }
        public IEnumerable<string> DataFile { get; set; }
    }
}