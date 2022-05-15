using Portal.Domain.Users;
using System.ComponentModel.DataAnnotations;

namespace Portal.Application.Users.Commands.EditUser
{
    public class EditUserDto
    {
        //===
        [Required]
        public Guid RoleId { get; set; }
        //===
        [EmailAddress]
        public string? Email { get; set; }
        //===
        [MaxLength(255)]
        public string? Firstname { get; set; }
        //===
        [MaxLength(255)]
        public string? Lastname { get; set; }
        //===
        [MaxLength(255)]
        public string? FatherName { get; set; }
        //===
        [MaxLength(255)]
        public string? Job { get; set; }
        //===
        [MaxLength(255)]
        public string? Education { get; set; }
        //===
        [MaxLength(260)]
        public string? Address { get; set; }
        //===
        [MaxLength(20)]
        public string? Fax { get; set; }
        //===
        [MaxLength(255)]
        public string? Company { get; set; }
        //===
        [MaxLength(255)]
        public string? ZipPostalCode { get; set; }
        //===
        [MaxLength(255)]
        public string? City { get; set; }
        //===
        [MaxLength(255)]
        public string? County { get; set; }
        //===
        [MaxLength(255)]
        public int? CurrencyId { get; set; }
        //===
        public int? LanguageId { get; set; }
        //===
        public DateTime? CreatedOnUtc { get; set; }
        //===
        [MaxLength(255)]
        public DateTime? LastLoginDateUtc { get; set; }
        //===
        public DateTime? LastActivityDateUtc { get; set; }
        //===
        public DateTime? DateOfBirth { get; set; }
        //===
        public GenederType? Geneder { get; set; }
        //===
        public bool IsActiveMobile { get; set; } = false;
        //===
        public bool IsActiveEmail { get; set; } = false;
        //===
        public string? Token { get; set; }
        //===
        public string? ActiveCode { get; set; }
        //===
        public Guid? DocumentId { get; set; }
        //===
        public decimal? Wallet { get; set; }
    }
}