﻿namespace RevisionApp.Services.Dto.Response
{
    public class ValidateAccountResponse
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
    }
}
