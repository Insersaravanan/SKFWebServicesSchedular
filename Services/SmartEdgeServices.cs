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
    public class SmartEdgeServices
    {

        private readonly MonitorsRepo MonitorsRepo;
        private IConfiguration _configuration;
        public SmartEdgeServices(IConfiguration configuration)
        {
            MonitorsRepo = new MonitorsRepo(configuration);
            _configuration = configuration;
        }

        public async Task<string> CallServices()
        {

            var client = new RestClient("https://api-idap.infinite-uptime.com/login");

            JObject jObjectbody = new JObject();
            jObjectbody.Add("email", "skf@skf.com");
            jObjectbody.Add("password", "skf@123");

            var request = new RestRequest("", Method.POST);
            request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);
            IRestResponse restResponse = client.Execute(request);

            //return Content(restResponse.Content);

            string jsonString = restResponse.Content;
            JObject jobj = JObject.Parse(jsonString);
            string token = (string)jobj.SelectToken("accessToken");


            var client1 = new RestClient("https://api-idap.infinite-uptime.com/api/2.0/md/get-events?monitorId=1458&from=2020-06-10T07:30:00Z&to=2020-07-30T08:30:00Z");
            client1.Timeout = -1;
            var request1 = new RestRequest(Method.GET);
            request1.AddHeader("Authorization", "Bearer" + token);
            request1.AddHeader("Content-Type", "application/json");
            //request1.AddParameter("application/json", "{\"id\":43,\"qtype\":2}", ParameterType.RequestBody);
            IRestResponse response1 = client1.Execute(request1);
            List<FftViewModel> response = JsonConvert.DeserializeObject<List<FftViewModel>>(response1.Content);
            foreach (FftViewModel uivm in response)
            {
                await MonitorsRepo.SaveOrUpdatefft(uivm);
            }

            return "";

            //var client2 = new RestClient("https://api-idap.infinite-uptime.com/api/2.0/md/trend-history?monitorId=1458&from=2020-07-30T07:30:00Z&to=2020-07-30T08:30:00Z&intervalUnit=minute&intervalValue=1");
            //client2.Timeout = -1;
            //var request2 = new RestRequest(Method.GET);
            //request2.AddHeader("Authorization", "Bearer" + token);
            //request2.AddHeader("Content-Type", "application/json");
            //request2.AddParameter("application/json", "Monitor ID : 1458\r\nFrom : '2020-07-29'\r\nTo: '2020-08-29'", ParameterType.RequestBody);
            //IRestResponse response2 = client2.Execute(request2);
            /////List<MonitorsViewModel> response = JsonConvert.DeserializeObject<List<MonitorsViewModel>>(response1.Content);
            //return Content(response2.Content);

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
    }
}
