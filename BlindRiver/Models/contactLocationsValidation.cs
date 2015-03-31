using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace BlindRiver.Models
{

    [MetadataType(typeof(contactLocationsValidation))]
    public partial class contact_location
    {
    }

     [Bind(Exclude = "id")]
    public class contactLocationsValidation
    {
        [DisplayName("Title")]
        [Required]
        public string title { get; set; }

        [DisplayName("Address")]
        [Required]
        public string address { get; set; }

        [StringLength(12)]
        [DisplayName("Phone")]
        [Required]
        [RegularExpression(@"^\(\d{3}\) ?\d{3}( |-)?\d{4}|^\d{3}( |-)?\d{3}( |-)?\d{4}$")]
        public string phone { get; set; }

        [DisplayName("Fax")]
        [Required]
        public string fax { get; set; }

        [DisplayName("Latitide")]
        [Required]
        public float latitude { get; set; }

        [DisplayName("Longitude")]
        [Required]
        public float longitude { get; set; }
    }
}