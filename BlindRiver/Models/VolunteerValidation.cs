using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace BlindRiver.Models
{

    [MetadataType(typeof(VolunteerValidation))]
    public partial class VolunteerOpportunities
    {
    }

    [Bind(Exclude = "id")]
    public partial class VolunteerValidation
    {
        [DisplayName("Volunteer Position: ")]
        [Required]
        public string position { get; set; }

        [DisplayName("Description: ")]
        [Required]
        public string description { get; set; }

        [DisplayName("Code: ")]
        [Required]
        public string code { get; set; }
    }
}