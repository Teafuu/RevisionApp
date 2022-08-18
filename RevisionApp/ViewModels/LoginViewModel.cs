using RevisionApp.Services;

namespace RevisionApp.ViewModels
{
    public class LoginViewModel
    {
        private readonly RevisionService service;

        public string Username { get; set; }
        public string Password { get; set; }
        public string Title { get; set; } = "Welcome!";
        public Command LoginCommand => new Command(Login);
        public Command RegisterAccountCommand => new Command(RegisterAccount);

        public LoginViewModel(RevisionService service)
        {
            this.service = service;
        }
        private void Login()
        {
            if (ValidateCredentials(Username, Password) == true)    
            {
                Shell.Current.GoToAsync("//HomePage");
            }

            else
            {
                Title = "Wrong Credentials";
            }
        }
        private void RegisterAccount() 
        {
            Shell.Current.GoToAsync("//CreateAccountPage");
        }

        bool ValidateCredentials(string username, string password)
        {
            return service.Login(username, password);
        }
    }
}
