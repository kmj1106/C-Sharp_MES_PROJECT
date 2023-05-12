using FlowerVO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace APIFileUpload.Controllers
{
    public class FileUploadController : ApiController
    {
        // POST https://localhost:44330/api/FileUpload
        public HttpResponseMessage Post()
        {
            HttpResponseMessage result = null;

            string name = HttpContext.Current.Request["name"];
            if (HttpContext.Current.Request.Files.Count > 0)
            {
                foreach (string file in HttpContext.Current.Request.Files)
                {
                    var postedFile = HttpContext.Current.Request.Files[file];

                    string orgFileName = postedFile.FileName;
                    string filePath = HttpContext.Current.Server.MapPath("~/Uploads/");
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    postedFile.SaveAs(filePath + orgFileName);

                    //DB insert
                }

                result = Request.CreateResponse(HttpStatusCode.Created);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return result;
        }

        // GET https://localhost:44330/api/FileUpload/GetFileList
        [HttpGet]
        [Route("api/FileUpload/GetFileList")]
        public List<FilePathVO> GetFileList()
        {
            List<FilePathVO> list = new List<FilePathVO>();

            //업로드 경로에서 파일정보를 하나씩 읽어서 Add
            string filePath = HttpContext.Current.Server.MapPath("~/Uploads");
            DirectoryInfo dir = new DirectoryInfo(filePath);
            foreach (FileInfo item in dir.GetFiles())
            {
                list.Add(new FilePathVO
                {
                    FileName = item.Name,
                    Path = filePath,
                    Length = item.Length
                });
            }
            return list;
        }
    }
}
