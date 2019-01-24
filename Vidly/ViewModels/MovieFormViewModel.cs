using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            Stock = movie.Stock;
            GenreTypeId = movie.GenreTypeId;
            AvailableStock = movie.Stock;
        }

        [Display(Name = "Current amount available")] public byte AvailableStock { get; set; }

        public IEnumerable<GenreType> GenreTypes { get; set; }
        public int? Id { get; set; }

        [Required] public string Name { get; set; }

        [Required] [Display(Name = "Genre")] public byte? GenreTypeId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [Required]
        public byte? Stock { get; set; }

        public string Title => Id != 0 ? "Edit Movie" : "New Movie";
    }
}