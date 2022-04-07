using System.ComponentModel.DataAnnotations;

namespace Portal.Domain.Users;

public class Permission : BaseEntity
{
    public Permission()
    {
        RolePermissions = new List<RolePermission>();
    }

    #region Fields
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Name { get; set; } = string.Empty;
    #endregion

    #region NavigationProperty
    public ICollection<RolePermission> RolePermissions { get; set; }
    #endregion

}
