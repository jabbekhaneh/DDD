namespace Portal.Application.Users.Queries.GetUsers
{
    public class GetUsersDto
    {
        public GetUsersDto()
        {
            Users = new List<GetUserDto>();
        }
        public List<GetUserDto> Users { get; set; }
        public int PageSize { get; set; }
        public int PageId { get; set; }
    }

    public class GetUserDto
    {
        
        public string Mobile { get; set; } = string.Empty;
        //===
        public string? Email { get; set; }
        //===
        public string? Name { get; set; }
        //===
        public string? FatherName { get; set; }
        public bool IsActiveMobile { get; set; } = false;
        //===
        public bool IsActiveEmail { get; set; } = false;
        //===
        public Guid? DocumentId { get; set; }
        //===
        public decimal? Wallet { get; set; }

    }
}