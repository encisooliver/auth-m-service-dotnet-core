using System;
using auth_project.Data;
using auth_project.Models;
using auth_project.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace auth_project.Repositories;

public class UserRepository: IUserRepository
{
    private readonly AuthContext _context;

    public UserRepository(AuthContext context){
        _context = context;
    }

    public async Task<IEnumerable<UserModel>> GetAllAsync(){
        return await _context.Users.ToListAsync();
    }

    public async Task<UserModel?> GetByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<UserModel> AddAsync(UserModel user)
    {
        var _user = await _context.Users.AddAsync(user);
        user.Id = _user.Entity.Id;
        _context.SaveChangesAsync();
        return await Task.FromResult(user);
    }

    public async Task<bool> UpdateAsync(UserModel user)
    {
        _context.Users.Update(user);
        _context.SaveChangesAsync();
        return await Task.FromResult(true);
    }

    public async Task<bool> DeleteAsync(UserModel user)
    {
        _context.Users.Remove(user);
        _context.SaveChangesAsync();
        return await Task.FromResult(true);
    }

    public async Task<bool> SaveAsync()
    {
        var saved = await _context.SaveChangesAsync();
        return saved > 0;
    }

}
