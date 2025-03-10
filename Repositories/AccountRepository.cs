using System;
using auth_project.Data;
using auth_project.DTOs.Account;
using auth_project.Interfaces;
using auth_project.Models;

namespace auth_project.Repositories;

public class AccountRepository: IAccountInterface
{
    private readonly AuthContext _authContext;

    public AccountRepository(AuthContext authContext)
    {
        _authContext = authContext;
    }   

    public async Task<bool> Register(RegistrationDTO register, string hashPassword)
    {
        await _authContext.Users.AddAsync(new UserModel{
            Name = register.Name,
            UserName = register.UserName,
            Email = register.Email,
            Password = hashPassword
        });
        await _authContext.SaveChangesAsync();
        return await Task.FromResult(true);
    }

    public async Task<UserModel> GetAccount(string userName)
    {
        return await Task.FromResult(_authContext.Users.FirstOrDefault(d => d.UserName == userName));
    }
}
