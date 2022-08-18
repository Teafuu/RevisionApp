using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisionApp.Services
{
    public class RevisionService
    {
        public RevisionService(HttpClient client)
        {
            Client = client;
        }

        public HttpClient Client { get; }

        public bool CreateAccount(string username, string password)
        {
            var response = Client.PostAsync($"User/CreateUser?email={username}&password={password}", new StringContent("")).Result;
            return response.Content.ReadAsStringAsync().Result == "true";
        }

        public bool Login(string username, string password)
        {
            var response = Client.GetStringAsync($"User/ValidateCredentials?email={username}&password={password}").Result;

            return response.ToLower() == "true";
        }
    }
}
