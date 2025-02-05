using System;

namespace auth_project.Entities;

public class User
{
    public int Id {get; set;}
    public required string Name {get; set;}
    public required string UserName {get; set;}
    public required string Email {get; set;}
    public int UserTypeId {get; set;}
    public UserType? UserType {get; set;}
}
