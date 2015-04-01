using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace BlindRiver.Models
{
    [MetadataType(typeof(bookAppValidation))]
    public partial class bookApp
    { }

    [Bind(Exclude = "id")]
    public class bookAppValidation
    {
        [DisplayName("Name: ")]
        [Required]
        public string name { get; set; }

        [DisplayName("Phone: ")]
        [Required]
        [RegularExpression(@"^\(\d{3}\) ?\d{3}( |-)?\d{4}|^\d{3}( |-)?\d{3}( |-)?\d{4}$")]
        public int phone { get; set; }

        [DisplayName("Email: ")]
        [Required]
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$")]
        public string email { get; set; }

        [DisplayName("Date Of Appointment: ")]
        [Required]
        public DateTime doa { get; set; }

        [DisplayName("Purpose: ")]
        [Required]
        public string purpose { get; set; }
    }

}