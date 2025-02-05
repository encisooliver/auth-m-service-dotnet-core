using System;
using auth_project.Data;
using auth_project.Entities;
using auth_project.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace auth_project.Repositories;

public class UserRepositories: IUserRepository
{
    private readonly AuthContext _context;

    public UserRepositories(AuthContext context){
        _context = context;
    }

    public IEnumerable<User> GetAll(){
        return _context.Users.ToList();
    }

    public User GetById(int id){
        return _context.Users.Find(id);
    }
    public Boolean Add(User user){
        _context.Users.Add(user);
        return Save();
    }
    public Boolean Update(User user){
        _context.Users.Update(user);
        return Save();
    }
    public Boolean Delete(User user){
        _context.Users.Remove(user);
        return Save();
    }

    public Boolean Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;        
    }
}
