using System;

namespace auth_project.Models;

public class UserModel
{
    public int Id {get; set;}
    public string Name {get; set;}
    public string UserName {get; set;}
    public string Email {get; set;}
    public string Password {get; set;}
}
