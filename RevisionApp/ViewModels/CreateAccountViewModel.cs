using RevisionApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisionApp.ViewModels

{
    public class CreateAccountViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public RevisionService Service { get; }

        public Command RegisterCommand => new Command(CreateAccount);
        public CreateAccountViewModel(RevisionService service)
        {
            Service = service;
        }

        private void CreateAccount()
        {
            if(Service.CreateAccount(Username, Password))
            {
                Shell.Current.GoToAsync("//MainPage");
            }
        }
    }
}
