using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal.Domain.Users;

public class UserLoginHistory : BaseEntity
{
    public UserLoginHistory()
    {

    }

    #region Fields
    [Required]
    public string IpAddress { get; set; } = string.Empty;
    public string? OS { get; set; }
    [Required]
    public string? ShortMessage { get; set; }
    [Required]
    public DateTime LoginDate { get; set; }
    public bool IsSuccess { get; set; }
    [Required]
    public Guid UserId { get; set; }
    #endregion

    #region NavigationProperty
    [ForeignKey("UserId")]
    public User? User { get; set; }
    #endregion

}

