using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using SKFWebServicesSchedular.Models;
using SKFWebServicesSchedular.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SKFWebServicesSchedular.Services
{
    public class CallApiService
    {

        private readonly CompanyRepo CompanyRepo;
        private IConfiguration _configuration;
        public CallApiService(IConfiguration configuration)
        {
            CompanyRepo = new CompanyRepo(configuration);
            _configuration = configuration;
        }

        public async Task<string> CallService()
        {
            try
            {

                var client = new RestClient("https://sso-api.staging.users.enlight.skf.com/sign-in/initiate");

                JObject jObjectbody = new JObject();
                //jObjectbody.Add("X-Gravitee-Api-Key", "d0fc013c-b260-4482-81ad-de95f7e4a9b4");
                jObjectbody.Add("username", "saravanan.s@insersolutions.com");
                jObjectbody.Add("password", "Inser@321");

                var request = new RestRequest("", Method.POST);
                request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);
                IRestResponse restResponse = client.Execute(request);

                //return Content(restResponse.Content);

                string jsonString = restResponse.Content;
                JObject jobj = JObject.Parse(jsonString);
                string token = (string)jobj.SelectToken("data.tokens.accessToken");

                //return token;
                DateTime dt = DateTime.Now;
                DateTime dt1 = dt.AddHours(-2);

                //var client1 = new RestClient("https://test.snaplogic.skf.com:8082/v1/enlight/hierarchy/company?fromDate=" + dt1.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'") + "&toDate=" + dt.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'"));
                //var client1 = new RestClient("https://test.snaplogic.skf.com:8082/v1/enlight/hierarchy/company?fromDate=2020-04-01T06:56:21Z&toDate=2020-06-01T06:56:21Z");
                //client1.Timeout = -1;
                //var request1 = new RestRequest(Method.GET);
                //request1.AddHeader("X-Enlight-AccessToken", token);
                //request1.AddHeader("X-Gravitee-Api-Key", "d0fc013c-b260-4482-81ad-de95f7e4a9b4");
                ////request1.AddHeader("Authorization", "Bearer" + token);
                ////request1.AddHeader("Content-Type", "application/json");
                ////request1.AddParameter("application/json", "{\"fromDate\":" + dt + ",\"toDate\":" + dt1 + "}", ParameterType.RequestBody);
                //IRestResponse response1 = client1.Execute(request1);
                //string jsonobj = response1.Content;
                //JObject jobj1 = JObject.Parse(jsonobj);
                //List<CompanyViewModel> response = JsonConvert.DeserializeObject<List<CompanyViewModel>>((string)jobj1.SelectToken("company").ToString());

                //foreach (CompanyViewModel uivm in response)
                //{
                //  await CompanyRepo.SaveOrUpdate(uivm);  
                //}
                //return "";
                var client2 = new RestClient("https://test.snaplogic.skf.com:8082/v1/enlight/hierarchy/sites?fromDate=" + dt1.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'") + "&toDate=" + dt.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'"));
                //var client2 = new RestClient("https://test.snaplogic.skf.com:8082/v1/enlight/hierarchy/sites?fromDate=2020-04-01T06:56:21Z&toDate=2020-10-15T09:00:21Z");
                client2.Timeout = -1;
                var request1 = new RestRequest(Method.GET);
                request1.AddHeader("X-Enlight-AccessToken", token);
                request1.AddHeader("X-Gravitee-Api-Key", "d0fc013c-b260-4482-81ad-de95f7e4a9b4");
                //request1.AddHeader("Authorization", "Bearer" + token);
                //request1.AddHeader("Content-Type", "application/json");
                //request1.AddParameter("application/json", "{\"fromDate\":" + dt + ",\"toDate\":" + dt1 + "}", ParameterType.RequestBody);
                IRestResponse response1 = client2.Execute(request1);
                string jsonobj = response1.Content;
                JObject jobj1 = JObject.Parse(jsonobj);
                List<SitesViewModel> response = JsonConvert.DeserializeObject<List<SitesViewModel>>((string)jobj1.SelectToken("sites").ToString());

                foreach (SitesViewModel uivm in response)
                {
                    
                    await CompanyRepo.SaveOrUpdateSite(uivm);
                }
                return "";

                //var client3 = new RestClient("https://api-idap.infinite-uptime.com/api/2.0/md/equipment-history?monitorId=1458&from=2020-07-28T10:30:00Z&to=2020-07-28T12:30:00Z&type=report&direction=1");
                //client3.Timeout = -1;
                //var request3 = new RestRequest(Method.GET);
                ////request3.AddHeader("Authorization", "Bearer 9d411689-3fad-4f9b-a71c-2ed6bed6e6e8");
                //request3.AddHeader("Content-Type", "application/json");
                //request3.AddParameter("application/json", "Monitor ID : 1458\r\nFrom : '2020-08-07'\r\nTo: '2020-08-29'", ParameterType.RequestBody);
                //IRestResponse response3 = client3.Execute(request3);

                //return Content(response3.Content);

                //var client4 = new RestClient("https://api-idap.infinite-uptime.com/api/2.0/md/get-events?monitorId=1458&from=2020-06-10T07:30:00Z&to=2020-07-30T08:30:00Z");
                //client4.Timeout = -1;
                //var request4 = new RestRequest(Method.GET);
                ////request4.AddHeader("Authorization", "Bearer 9d411689-3fad-4f9b-a71c-2ed6bed6e6e8");
                //request4.AddHeader("Content-Type", "application/json");
                //request4.AddParameter("application/json", "Monitor ID : 1458\r\nFrom : '2020-08-28'\r\nTo: '2020-08-29'", ParameterType.RequestBody);
                //IRestResponse response4 = client4.Execute(request4);

                ////return Content(response4.Content);

                //var client5 = new RestClient("https://md-backend.infinite-uptime.com/iu/md/api/fft-data-time?monitorId=1458&from=2020-06-17T11:09:00Z&to=2020-07-18T11:09:00Z");
                //client5.Timeout = -1;
                //var request5 = new RestRequest(Method.GET);
                ////request5.AddHeader("Authorization", "Bearer 9d411689-3fad-4f9b-a71c-2ed6bed6e6e8");
                //request5.AddHeader("Content-Type", "application/json");
                //request5.AddParameter("application/json", "Monitor ID : 1458\r\nFrom : '2020-07-09'\r\nTo: '2020-08-29'", ParameterType.RequestBody);
                //IRestResponse response5 = client5.Execute(request5);

                ////return Content(response5.Content);


                //var client6 = new RestClient("https://md-backend.infinite-uptime.com/iu/md/api/fft-data?monitorId=1458&macId=94:54:93:49:CE:FE&selectAxis=Z&to=2020-07-09T00:19:46.385Z");
                //client6.Timeout = -1;
                //var request6 = new RestRequest(Method.GET);
                ////request6.AddHeader("Authorization", "Bearer 9d411689-3fad-4f9b-a71c-2ed6bed6e6e8");
                //request6.AddHeader("Content-Type", "application/json");
                //request6.AddParameter("application/json", "Monitor ID : 1458\r\nTimestamp: 2020-07-09T00:19:46.385Z", ParameterType.RequestBody);
                //IRestResponse response6 = client6.Execute(request6);

                //return Content(response6.Content);
            }
            catch (Exception ex)
            {
                throw new CustomException("Unable to Save Or Update, Please Contact Support!!!", "Error", true, ex);
            }
        }
    }
}
