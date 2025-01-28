using System.ComponentModel.DataAnnotations;

namespace auth_project.DTOs;

public record class UpdateUserDTO(
    int Id,
    [Required][StringLength(50)] string Name,
    [Required][StringLength(20)]string UserName,
    string Email
);
