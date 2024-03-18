using Sales.Api.Dtos.Authors;

namespace Sales.Api.Models
{
    public class AuthorGetModel : AuthorAddDto
    {
        public int phone { get; set; }

        public string? address { get; set; }

        public string? city { get; set; }

        public string? state { get; set; }

        public string? zip {  get; set; }
    }
}

