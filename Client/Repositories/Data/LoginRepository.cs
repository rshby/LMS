using Client.Base;
using Client.ViewModels;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Repositories.Data
{
    public class LoginRepository : GeneralRepository<LoginVM, string>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;
        private readonly IHttpContextAccessor contextAccessor;

        //Constructor
        public LoginRepository(Address address, string request = "accounts/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }

        //Login 
        public async Task<JwtTokenVM> Auth(LoginVM inputData)
        {
            JwtTokenVM token = null;

            StringContent content = new StringContent(JsonConvert.SerializeObject(inputData), Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync(request + "login", content);

            string response = await result.Content.ReadAsStringAsync();
            token = JsonConvert.DeserializeObject<JwtTokenVM>(response);

            return token;
        }
    }
}
