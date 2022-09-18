﻿using Newtonsoft.Json;
using RevisionApp.Services.Dto.Request;
using RevisionApp.Services.Dto.Response;
using System.Text;

namespace RevisionApp.Services
{
    public class RevisionService
    {
        public HttpClient Client { get; }

        public RevisionService(HttpClient client) => Client = client;
        
        public CreateAccountResponse CreateAccount(string email, string password)
        {
            try
            {
                var request = new CreateAccountRequest(email, password);
                var stringContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                var result = Client.PostAsync($"User/CreateUser", stringContent).Result;

                var response =
                    JsonConvert.DeserializeObject<CreateAccountResponse>(result.Content.ReadAsStringAsync().Result);

                return response;

            }
            catch (Exception e)
            {
                return new CreateAccountResponse { Error = e.Message, Success = false };
            }
        }

        public ValidateAccountResponse Login(string email, string password)
        {
            try
            {
                var request = new ValidateAccountRequest(email, password);
                var stringContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                var result = Client.PostAsync($"User/ValidateUser", stringContent).Result;

                var response =
                    JsonConvert.DeserializeObject<ValidateAccountResponse>(result.Content.ReadAsStringAsync().Result);

                return response;
            }
            catch(Exception e)
            {
                return new ValidateAccountResponse { Error = e.Message, Success = false};
            }
        }

        public void CreateTopic(CreateTopicRequest request)
        {
            try
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                var result = Client.PostAsync($"Topic/PostTopic", stringContent).Result;

                if (!result.IsSuccessStatusCode)
                    throw new Exception(result.Content.ReadAsStringAsync().Result);
            }
            catch (Exception e)
            {
                
            }
        }
        public void PatchTopic(PatchTopicRequest request)
        {
            try
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                var result = Client.PatchAsync($"Topic/PatchTopic", stringContent).Result;

                if (!result.IsSuccessStatusCode)
                    throw new Exception(result.Content.ReadAsStringAsync().Result);
            }
            catch (Exception e)
            {

            }
        }

        internal GetTopicsResponse GetTopics(int userId)
        {
            try
            {
                var result = Client.GetAsync($"Topic/GetTopics?id={userId}").Result;
                
                var response = JsonConvert.DeserializeObject<GetTopicsResponse>(result.Content.ReadAsStringAsync().Result);
                
                return response;
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}
