using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace BlindRiver.Models
{

    [MetadataType(typeof(contactsValidation))]
    public partial class contact
    {
    }

    [Bind(Exclude = "id")]
    public class contactsValidation
    {
        [DisplayName("Name")]
        [Required]
        public string name { get; set; }

        [DisplayName("Email")]
        [Required]
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$")]
        public string email { get; set; }

        [StringLength(12)]
        [DisplayName("Phone")]
        [Required]
        [RegularExpression(@"^\(\d{3}\) ?\d{3}( |-)?\d{4}|^\d{3}( |-)?\d{3}( |-)?\d{4}$")]
        public string phone { get; set; }

        [DisplayName("Subject")]
        [Required]
        public string subject { get; set; }

        [DisplayName("Message")]
        [Required]
        [AllowHtml]
        public string message { get; set; }

        [DisplayName("Reviewed")]
        [Required]
        public bool reviewed { get; set; }

        [DisplayName("Date")]
        [Required]
        public DateTime date { get; set; }

    }
}