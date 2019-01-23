using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class GenreType
    {
        public byte Id { get; set; }

        [Required] public string Name { get; set; }
    }
}