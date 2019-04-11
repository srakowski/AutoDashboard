using AutoDashboard.UniversalApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AutoDashboard.UniversalApp.Services
{
    class NhtsaVehicleInfoService : IVehicleInfoService
    {
        private static HttpClient _client = new HttpClient();

        public async Task<VehicleInfo> GetVehicleInfoByVin(string vinNumber)
        {
            var response = await _client.GetAsync(
                $"https://vpic.nhtsa.dot.gov/api/vehicles/decodevin/{vinNumber}?format=json");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var decodeResponse = JsonConvert.DeserializeObject<DecodeResponse>(data);
                var make = decodeResponse.Results.FirstOrDefault(r => r.Variable == "Make")?.Value;
                var model = decodeResponse.Results.FirstOrDefault(r => r.Variable == "Model")?.Value;
                var modelYear = decodeResponse.Results.FirstOrDefault(r => r.Variable == "Model Year")?.Value;
                return new VehicleInfo(make, model, modelYear);
            }
            else
            {
                throw new Exception($"http request to get vehicle information failed for vin {vinNumber}");
            }
        }

        private class DecodeResponse
        {
            public IEnumerable<DecodeResult> Results { get; set; }            
        }

        private class DecodeResult
        {
            public string Variable { get; set; }
            public string Value { get; set; }
        }
    }
}
