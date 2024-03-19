
namespace Sales.AplicacionCasosDEusos.Dtos.Author
{
    public record AuthorDto
    {
        public int phone { get; set; }

        public string? address { get; set; }

        public string? city { get; set; }

        public string? state { get; set; }

        public string? zip { get; set; }
    }
}
