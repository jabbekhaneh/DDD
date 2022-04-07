using System.ComponentModel.DataAnnotations;

namespace Portal.Domain
{
    public abstract partial class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
