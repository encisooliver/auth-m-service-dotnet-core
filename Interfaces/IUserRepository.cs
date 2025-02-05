using System;
using auth_project.Entities;

namespace auth_project.Interfaces;

public interface IUserRepository
{
    public IEnumerable<User> GetAll();
    public User GetById(int id);
    public Boolean Add(User user);
    public Boolean Update(User user);
    public Boolean Delete(User user);
}
