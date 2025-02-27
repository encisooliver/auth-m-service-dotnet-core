using System;
using auth_project.Models;

namespace auth_project.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<UserModel>> GetAllAsync();
    Task<UserModel?> GetByIdAsync(int id);
    Task<UserModel> AddAsync(UserModel user);
    Task<bool> UpdateAsync(UserModel user);
    Task<bool> DeleteAsync(UserModel user);
}
