using System.ComponentModel.DataAnnotations;

namespace HomeWorkBlazorWebAsssembly.Models
{
    public class AddressModel
    {
        [Required]
        public string StreetAdress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string State { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 2)]
        public string ZipCode { get; set; }


    }
}
