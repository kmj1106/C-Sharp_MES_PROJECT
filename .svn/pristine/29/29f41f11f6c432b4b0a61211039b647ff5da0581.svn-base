using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Configuration;
using System.Net.Http.Headers;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Net;
using FlowerVO;

namespace WindowsFormsFlower
{
    class CallService
    {
        HttpClient client = new HttpClient();


        public CallService()
        {
            string serverUrl = ConfigurationManager.AppSettings["apiurl"];
            client.BaseAddress = new Uri($"{serverUrl}api/FileUpload/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> GetListAsync<T>(string path)
        {
            T list = default(T);
            using (HttpResponseMessage res = await client.GetAsync(path))
            {
                if (res.IsSuccessStatusCode)
                {
                    list = JsonConvert.DeserializeObject<T>(await res.Content.ReadAsStringAsync());
                }
            }
            return list;
        }

        public async Task<FilePathVO> ServerUpload(string localFileName)
        {
            //파일명을 변경해서 업로드
            Random rnd = new Random();
            var fileStream = File.Open(localFileName, FileMode.Open);
            string uploadFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + rnd.Next(9999).ToString().PadLeft(4, '0');
            var uploadfile = uploadFileName + new FileInfo(localFileName).Extension;

            MultipartFormDataContent content = new MultipartFormDataContent();
            content.Add(new StreamContent(fileStream), "file1", uploadfile);

            FilePathVO image = new FilePathVO();
            using (HttpResponseMessage res = await client.PostAsync("", content))
            {
                if(res.IsSuccessStatusCode)
                {
                    image.IsSuccess = true;
                    image.FileName = uploadfile;
                }
                else
                {
                    image.IsSuccess = false;
                }
            }
            return image;
        }

        public bool LocalDownload(string fileUrl, string fileName)
        {
            try
            {
                string downloadPath = Application.StartupPath + @"\Downloads\";

                if (!Directory.Exists(downloadPath))
                    Directory.CreateDirectory(downloadPath);

                WebClient webClient = new WebClient();
                webClient.DownloadFile(fileUrl, downloadPath + fileName);
                return true;
            }
            catch(Exception err)
            {
                string msg = err.Message;
                return false;
            }
        }
    }
}
