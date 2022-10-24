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
        public string Error { get => _error; set { _error = value; OnPropertyChanged(nameof(Error));} }  // MAUI needs this to update UI

        public Command LoginCommand => new(Login); // Called on button click
        public Command RegisterAccountCommand => new(RegisterAccount); // Called on button click

        #region private properties
        private string _error;
        #endregion


        public LoginViewModel(RevisionService service)
        {
            _service = service;
        }
        private void Login()
        {
            if (!Email.Contains('@')) // Validating user input
            {
                Error = "Invalid Email";
                return;
            }

            var response = _service.Login(Email, Password);

            if (response.Success)
            {
                UserManager.UserId = response.UserId;
                UserManager.Name = response.Name;

                Shell.Current.GoToAsync("//HomePage"); // Navigates to login page
                return;
            }

            Error = response.Error;

        }
        private void RegisterAccount() 
        {
            Shell.Current.GoToAsync("//CreateAccountPage"); // Navigates Create create account page
        }
    }
}
