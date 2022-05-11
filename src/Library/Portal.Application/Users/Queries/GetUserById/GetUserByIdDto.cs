using Portal.Domain.Users;

namespace Portal.Application.Users.Queries.GetUserById
{
    public class GetUserByIdDto
    {
        
        public string Mobile { get; set; } = string.Empty;
        //===
        
        public Guid RoleId { get; set; }
        //===
        public string? Email { get; set; }
        //===
        
        public string? Firstname { get; set; }
        //===
        public string? Lastname { get; set; }
        //===
        public string? FatherName { get; set; }
        //===
        public string? Job { get; set; }
        //===
        public string? Education { get; set; }
        //===
        public string? Address { get; set; }
        //===
        public string? Fax { get; set; }
        //===
        public string? Company { get; set; }
        //===
        public string? ZipPostalCode { get; set; }
        //===
        public string? City { get; set; }
        //===
        public string? County { get; set; }
        //===
        public int? CurrencyId { get; set; }
        //===
        public int? LanguageId { get; set; }
        //===
        public DateTime? CreatedOnUtc { get; set; }
        //===
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