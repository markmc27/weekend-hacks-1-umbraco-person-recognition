using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace PersonRecognition.Models.Recognition
{
    public class KairosClient
    {
        public KairosClient()
        {
            AppId = ConfigurationManager.AppSettings["Kairos:Appid"] as string;
            ApiKey = ConfigurationManager.AppSettings["Kairos:ApiKey"] as string;
        }

        private static readonly string API_BASE_URL = "https://api.kairos.com";

        private string AppId { get; set; }
        private string ApiKey { get; set; }

        public async Task<EnrollResponseModel> Enroll(EnrollRequestModel request)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(API_BASE_URL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("app_id", AppId);
            client.DefaultRequestHeaders.Add("app_key", ApiKey);

            var response = await client.PostAsJsonAsync<EnrollRequestModel>("enroll", request);

            var responseModel = await response.Content.ReadAsAsync<EnrollResponseModel>();

            return responseModel;
        }

        public async Task<RecogniseResponseModel> Recognise(RecogniseRequestModel request)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(API_BASE_URL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("app_id", AppId);
            client.DefaultRequestHeaders.Add("app_key", ApiKey);

            var response = await client.PostAsJsonAsync<RecogniseRequestModel>("recognize", request);

            var responseModel = await response.Content.ReadAsAsync<RecogniseResponseModel>();

            return responseModel;
        }

        public bool CheckPerson(string subjectId)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(API_BASE_URL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("app_id", AppId);
            client.DefaultRequestHeaders.Add("app_key", ApiKey);

            var response = Task.Run(async () => await client.PostAsJsonAsync<ViewSubjectRequestModel>("gallery/view_subject", new ViewSubjectRequestModel
            {
                GalleryName = "MyGallery",
                SubjectId = subjectId
            })).Result;

            var responseModel = Task.Run(async () =>  await response.Content.ReadAsAsync<ViewSubjectResponseModel>()).Result;

            if (responseModel.Errors.Any())
            {
                return false;
            }

            return true;
        }
    }
}