using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal.Domain.Users;

public class RoleUser : BaseEntity
{
    public RoleUser()
    {

    }

    #region Fields
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public Guid RoleId { get; set; }
    #endregion

    #region NavigationProperty
    [ForeignKey("UserId")]
    public User? User { get; set; }
    [ForeignKey("RoleId")]
    public Role? Role { get; set; }
    #endregion
}
