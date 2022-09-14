using CommunityToolkit.Maui.Views;
using RevisionApp.Services;
using RevisionApp.Views;

namespace RevisionApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly RevisionService _service;

        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Title { get; set; } = "Welcome!";
        public string Error { get => _error; set { _error = value; OnPropertyChanged(nameof(Error));} } 

        public Command LoginCommand => new(Login);
        public Command RegisterAccountCommand => new(RegisterAccount);

        #region private properties
        private string _error;
        #endregion


        public LoginViewModel(RevisionService service)
        {
            _service = service;
        }
        private void Login()
        {
            Shell.Current.GoToAsync("//HomePage");

            return;

            if (!Email.Contains('@'))
            {
                Error = "Invalid Email";
                return;
            }

            var response = _service.Login(Email, Password);

            if (response.Success)
            {
                Shell.Current.GoToAsync("//HomePage");
                return;
            }

            Error = response.Error;

        }
        private void RegisterAccount() 
        {
            Shell.Current.GoToAsync("//CreateAccountPage");
        }

       
    }
}
