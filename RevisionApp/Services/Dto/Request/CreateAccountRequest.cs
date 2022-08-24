using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisionApp.Services.Dto.Request
{
    internal class CreateAccountRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public CreateAccountRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
