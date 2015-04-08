using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace BlindRiver.Models
{

    [MetadataType(typeof(VolunteerAppValidation))]
    public partial class Volunteer_Application
    {
    }

    [Bind(Exclude = "id")]
    public partial class VolunteerAppValidation
    {
        [DisplayName("First Name: ")]
        [Required]
        public string First_Name { get; set; }

        [DisplayName("Last Name: ")]
        [Required]
        public string Last_Name { get; set; }

        [DisplayName("Email: ")]
        [Required]
        public string Email { get; set; }

        [DisplayName("Phone: ")]
        [Required]
        public string Phone { get; set; }

        [DisplayName("Address: ")]
        [Required]
        public string Address1 { get; set; }

        [DisplayName("Address2: ")]
        [Required]
        public string Address2 { get; set; }

        [DisplayName("City: ")]
        [Required]
        public string City { get; set; }

        [DisplayName("Province: ")]
        [Required]
        public string Province { get; set; }

        [DisplayName("Postal Code: ")]
        [Required]
        public string Postal_Code { get; set; }

        [DisplayName("Volunteer Position Code: ")]
        [Required]
        public string Position_Code { get; set; }


    }
}