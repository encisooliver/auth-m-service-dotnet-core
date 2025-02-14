using System;

namespace auth_project.DTOs.Account;

public class RegistrationDTO
{
    public String Name {get; set;}
    public String UserName {get; set;}
    public String Email {get; set;}
    public String Password {get; set;}
}
