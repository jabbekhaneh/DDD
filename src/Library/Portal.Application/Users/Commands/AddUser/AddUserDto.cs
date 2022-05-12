using System.ComponentModel.DataAnnotations;

namespace Portal.Application.Users.Commands.AddUser;

public class AddUserDto
{

    
    [Required]
    public string Mobile { get; set; } = string.Empty;
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string? Firsname { get; set; }
    [Required]
    public string? Lastname { get; set; }
    [Required]
    public Guid RoleId { get; set; }

}
