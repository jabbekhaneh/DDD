using System.ComponentModel.DataAnnotations;

namespace Portal.Application.Users.Commands.AddUser;

public class AddUserResponseDto
{

    [MaxLength(255)]
    public string? Firtsname { get; set; }
    [MaxLength(255)]
    public string? Lastname { get; set; }
    [Required]
    public string Mobile { get; set; } = string.Empty;

}
