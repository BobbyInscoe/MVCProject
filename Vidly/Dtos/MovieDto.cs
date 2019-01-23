using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required] [StringLength(255)] public string Name { get; set; }

        public GenreTypeDto GenreType { get; set; }
        public byte GenreTypeId { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        public byte Stock { get; set; }
    }
}