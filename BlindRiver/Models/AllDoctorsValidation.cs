using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace BlindRiver.Models
{
    [MetadataType(typeof(AllDoctorsValidation))]
    public partial class doctor
    {
    }

    [Bind(Exclude="Id")]
    public class AllDoctorsValidation {

        [DisplayName("First Name: ")]
        [Required]
        public string firstName { get; set; }

        [DisplayName("Last Name: ")]
        [Required]
        public string lastName { get; set; }

        [DisplayName("Title: ")]
        [Required]
        public string title { get; set; }

        [DisplayName("Department: ")]
        [Required]
        public string department { get; set; }

        [DisplayName("Phone: ")]
        [Required]
        [RegularExpression(@"^\(\d{3}\) ?\d{3}( |-)?\d{4}|^\d{3}( |-)?\d{3}( |-)?\d{4}$")]
        public int phone { get; set; }

        [DisplayName("Email: ")]
        [Required]
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$")]
        public string email { get; set; }
    }
}