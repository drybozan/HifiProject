using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace HiFi.Api.Controllers
{
    public class PictureUploadApiController : ApiController
    {
        //POST
        public HttpResponseMessage Upload()
        {
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                string path = HttpContext.Current.Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    string dir = Path.GetDirectoryName(postedFile.FileName);
                    string fNAme = Path.GetFileNameWithoutExtension(postedFile.FileName);
                    string fExt = Path.GetExtension(postedFile.FileName);
                    var filePath = path+ postedFile.FileName;
                    int i = 1;
                    while (File.Exists(filePath))
                    {
                        filePath = Path.Combine(path, fNAme + "_" + i + fExt);
                        i++;
                    }
                    postedFile.SaveAs(filePath);
                    docfiles.Add(filePath);
                }

                result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;
        }
    }
}