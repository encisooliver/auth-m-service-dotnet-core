using System;

namespace auth_project.Models;

public class UserModel
{
    public Int32 Id {get; set;}
    public String Name {get; set;}
    public String UserName {get; set;}
    public String Email {get; set;}
    public String Password {get; set;}
}
