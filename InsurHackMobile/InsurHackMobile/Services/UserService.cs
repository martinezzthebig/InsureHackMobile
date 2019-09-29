using System;
using System.Net;
using System.Threading.Tasks;
using InsurHackMobile.Models;
using Newtonsoft.Json;
using RestSharp;

namespace InsurHackMobile.Services
{
    public class UserService : IUserService
    {

        public async Task<User> SignInUser(string email, string password)
        {
            var client = new RestClient(EnvironmentConstants.API_BASE_URL);
            var request = new RestRequest("user/signin", Method.POST, DataFormat.Json);
            var user = new User()
            {
                EMail = email,
                Password = password
            };
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(user),
                ParameterType.RequestBody);
            var response = await client.ExecuteTaskAsync(request);

            if (response.StatusCode == HttpStatusCode.BadRequest)
                throw new Exception(response.ErrorMessage);

            var retrievedUser = JsonConvert.DeserializeObject<User>(response.Content);
            return retrievedUser;
        }

        public async Task SingUpUser(User user)
        {
            var client = new RestClient(EnvironmentConstants.API_BASE_URL);
            var request = new RestRequest("user/signup", Method.POST, DataFormat.Json);
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(user),
                ParameterType.RequestBody);
            var response = await client.ExecuteTaskAsync(request);

            if (response.StatusCode == HttpStatusCode.BadRequest)
                throw new Exception(response.ErrorMessage);
        }
    }
}
