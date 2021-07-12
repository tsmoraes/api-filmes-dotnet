using System;

namespace CatalogoAPI.Models
{
    public class CatalogoFilme
    {
        public long Id { get; set; }
        public string Filme { get; set; }
        public bool JaAssisti { get; set; }
    }
}