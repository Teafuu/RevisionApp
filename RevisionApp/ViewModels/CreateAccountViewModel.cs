using RevisionApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisionApp.ViewModels

{
    public class CreateAccountViewModel : BaseViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ValidatePassword { get; set; }
        public string Error { get => _error; set { _error = value; OnPropertyChanged(); } }

        private readonly RevisionService _service;
        public Command RegisterCommand => new Command(CreateAccount);

        #region private properties
        private string _error;
        #endregion
        public CreateAccountViewModel(RevisionService service)
        {
            _service = service;
        }

        private void CreateAccount()
        {
            if (Password != ValidatePassword)
            {
                Error = "Password mismatch";
                Password = "";
                ValidatePassword = "";
                return;
            }

            if (!Email.Contains("@"))
            {
                Error = "Invalid Email";
                return;
            }

            var result = _service.CreateAccount(Email, Password);

            if(result.Success)
            {
                Shell.Current.GoToAsync("//MainPage");
                return;
            }

            Error = result.Error;
        }
    }
}
