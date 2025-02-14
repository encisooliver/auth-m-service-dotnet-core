using System;
using auth_project.DTOs.Account;
using auth_project.Models;

namespace auth_project.Interfaces;

public interface IAccountInterface
{
    public Boolean Register(RegistrationDTO register, String hashPassword);
    public UserModel? GetAccount(String userName);
}
