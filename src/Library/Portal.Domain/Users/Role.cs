using System.ComponentModel.DataAnnotations;

namespace Portal.Domain.Users;

public class Role : BaseEntity
{

    #region Cons
    public Role()
    {
        RolePermissions = new List<RolePermission>();
        RoleUsers = new List<RoleUser>();
    }
    #endregion

    #region Fields
    [Required]
    public string Title { get; set; } = string.Empty;
    #endregion

    #region NavigationProperty
    public ICollection<RolePermission> RolePermissions { get; set; }
    public ICollection<RoleUser> RoleUsers { get; set; }
    #endregion


}
