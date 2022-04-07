using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal.Domain.Users;

public class RolePermission : BaseEntity
{
    #region Fields
    [Required]
    public Guid RoleId { get; set; }
    [Required]
    public Guid PermissionId { get; set; }
    #endregion

    #region NavigationProperty

    [ForeignKey("RoleId")]
    public Role? Role { get; set; }
    [ForeignKey("PermissionId")]
    public Permission? Permission { get; set; }

    #endregion
}
