namespace Sales.Api.Dtos.Authors
{
    public class AuthorAddDto : AuthorsDtoBase
    {
        public int Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
    }
}
