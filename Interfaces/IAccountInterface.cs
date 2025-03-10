using System;
using auth_project.DTOs.Account;
using auth_project.Models;

namespace auth_project.Interfaces;

public interface IAccountInterface
{
    Task<bool> Register(RegistrationDTO register, string hashPassword);
    Task<UserModel>? GetAccount(string userName);
}
