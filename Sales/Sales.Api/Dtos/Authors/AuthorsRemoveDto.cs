namespace Sales.Api.Dtos.Authors
{
    public class AuthorsRemoveDto : DtosBase
    {
        public int phone { get; set; }

        public string? address { get; set; }

        public string? city { get; set; }

        public string? state { get; set; }

        public string? zip { get; set; }
    }
}
