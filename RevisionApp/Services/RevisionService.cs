using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RevisionApp.Services.Dto.Request;
using RevisionApp.Services.Dto.Response;

namespace RevisionApp.Services
{
    public class RevisionService
    {
        public RevisionService(HttpClient client)
        {
            Client = client;
        }

        public HttpClient Client { get; }

        public CreateAccountResponse CreateAccount(string email, string password)
        {
            var request = new CreateAccountRequest(email, password);
            var stringContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var result = Client.PostAsync($"User/CreateUser", stringContent).Result;

            var response =
                JsonConvert.DeserializeObject<CreateAccountResponse>(result.Content.ReadAsStringAsync().Result);

            return response;
        }

        public ValidateAccountResponse Login(string email, string password)
        {
            var request = new ValidateAccountRequest(email, password);
            var stringContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var result = Client.PostAsync($"User/ValidateUser", stringContent).Result;

            var response =
                JsonConvert.DeserializeObject<ValidateAccountResponse>(result.Content.ReadAsStringAsync().Result);

            return response;
        }

        internal GetTopicsResponse GetTopics(int userId)
        {
            var result = Client.GetAsync($"Topic/GetTopics?id={userId}").Result;

            var response = JsonConvert.DeserializeObject<GetTopicsResponse>(result.Content.ReadAsStringAsync().Result);

            return response;
        }
    }
}
