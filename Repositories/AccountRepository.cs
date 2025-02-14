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

    public Boolean Register(RegistrationDTO register, String hashPassword)
    {
        UserModel user = new UserModel{
            Name = register.Name,
            UserName = register.UserName,
            Password = hashPassword
        };
        _authContext.Users.Add(user);
        return Save();
    }

    public UserModel? GetAccount(String userName)
    {
        return _authContext.Users.Where(d => d.UserName == userName).FirstOrDefault();
    }

    private Boolean Save()
    {
        return _authContext.SaveChanges() > 0 ? true :false;
    }
}
