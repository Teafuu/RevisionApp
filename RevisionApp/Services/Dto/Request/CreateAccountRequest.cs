namespace RevisionApp.Services.Dto.Request
{
    internal class CreateAccountRequest
    {
        public string Email { get; set; }
        public string Name { get; }
        public string Password { get; set; }

        public CreateAccountRequest(string email, string name, string password)
        {
            Email = email;
            Name = name;
            Password = password;

        }
    }
}
