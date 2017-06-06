using Mechanix.Common;
using Mechanix.Domain;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace Mechanix.WinFormsApp.Workflows
{
    public class MechanixWorkflow
    {
        private const string ServicesEndpoint = "http://localhost:63312/api/services";
        private const string CarEndpoint = "http://localhost:63312/api/cars";
        private readonly HttpClient client;

        public MechanixWorkflow()
        {
            client = new HttpClient();
        }

        public List<Service> GetServices()
        {
            var result = client.GetStringAsync(ServicesEndpoint).Result;

            var services = JsonConvert.DeserializeObject<List<Service>>(result);

            return services;
        }

        public Result Create(Car car)
        {
            var result = client.PostAsJsonAsync(CarEndpoint, car).Result;

            return JsonConvert.DeserializeObject<Result>(result.Content.ReadAsStringAsync().Result);
        }
    }
}
