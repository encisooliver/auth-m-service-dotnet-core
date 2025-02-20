using System;

namespace auth_project.DTOs.Account;

public class RegistrationDTO
{
    public string Name {get; set;}
    public string UserName {get; set;}
    public string Email {get; set;}
    public string Password {get; set;}
}
