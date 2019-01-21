using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    /// <summary>
    /// Movie class. Contains Id and Name
    /// </summary>
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public GenreType GenreType { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreTypeId { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "Number in Stock")]
        public byte Stock { get; set; }
    }
}