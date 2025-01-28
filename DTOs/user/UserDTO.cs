namespace auth_project.DTOs;

public record class UserDTO(
    int Id,
    string Name,
    string UserName,
    string Email
);