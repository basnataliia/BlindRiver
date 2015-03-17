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
        public string email { get; set; }

        [DisplayName("Phone")]
        [Required]
        public string phone { get; set; }

        [DisplayName("Subject")]
        [Required]
        public string subject { get; set; }

        [DisplayName("Message")]
        [Required]
        public string message { get; set; }
    }
}