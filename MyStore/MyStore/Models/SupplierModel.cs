using System.ComponentModel.DataAnnotations;

namespace MyStore.Models
{
    public class SupplierModel
    {

        public int Supplierid { get; set; }

        [Required]
        [MinLength(5)]
        public string Companyname { get; set; } = null!;
        [Required]
        [MinLength(5)]
        public string Contactname { get; set; } = null!;

        public string Contacttitle { get; set; } = null!;
        [Required]
        [MinLength(5)]
        public string Address { get; set; } = null!;

        [Required]

        public string City { get; set; } = null!;

        public string? Region { get; set; }

        public string? Postalcode { get; set; }

        [Required]
        public string Country { get; set; } = null!;

        [Required]
        [Phone]
        public string Phone { get; set; } = null!;

        public string? Fax { get; set; }

    }
}
