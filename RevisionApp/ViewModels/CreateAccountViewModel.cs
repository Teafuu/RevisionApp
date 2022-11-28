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
        public string Name { get; set; }
        public string Password { get => _password; set { _password = value; OnPropertyChanged(); } }
        public string ValidatePassword { get => _validatePassword; set { _validatePassword = value; OnPropertyChanged(); } }
        public string Error { get => _error; set { _error = value; OnPropertyChanged(); } }

        private readonly RevisionService _service;
        public Command RegisterCommand => new Command(CreateAccount);

        #region private properties
        private string _error;
        private string _password;
        private string _validatePassword;
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

            if (!Email.Contains('@'))
            {
                Error = "Invalid Email";
                return;
            }

            if (string.IsNullOrEmpty(Name))
            {
                Error = "Name is Empty";
                return;
            }   
             
            var result = _service.CreateAccount(Email, Name, Password, Preferences.Get("DeviceToken", ""));

            if(result.Success)
            {
                Shell.Current.GoToAsync("//MainPage");
                return;
            }

            Error = result.Error;
        }
    }
}
