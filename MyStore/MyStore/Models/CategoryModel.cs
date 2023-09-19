using System.ComponentModel.DataAnnotations;

namespace MyStore.Models
{
    public class CategoryModel
    {
        public int Categoryid { get; set; }

        [Required]
        public string Categoryname { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Trebuie sa fie o valoare data!")]
        [MaxLength(20)]
        public string Description { get; set; }
    }
}
