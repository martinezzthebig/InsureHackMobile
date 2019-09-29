using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using InsurHackMobile.Models;
using Newtonsoft.Json;
using RestSharp;

namespace InsurHackMobile.Services
{
    public class ProfessionService : IProfessionService
    {
        public async Task<List<Profession>> GetAllProfessions()
        {
            var client = new RestClient(EnvironmentConstants.API_BASE_URL);
            var request = new RestRequest("profession/all", Method.GET, DataFormat.Json);
            var response = await client.ExecuteTaskAsync(request);

            if (response.StatusCode == HttpStatusCode.BadRequest)
                throw new Exception(response.ErrorMessage);

            var professions = JsonConvert.DeserializeObject<List<Profession>>(response.Content);
            return professions;
        }
    }
}
