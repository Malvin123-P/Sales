﻿namespace Sales.AplicacionCasosDEusos.Dtos.Author
{
    public class AuthorsUpdateDto : AuthorsDtoBase
    {
        public string? phone { get; set; }

        public string? address { get; set; }

        public string? city { get; set; }

        public string? state { get; set; }

        public string? zip { get; set; }
    }
}

