using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;
namespace BlindRiver.Models
{

    [MetadataType(typeof(serviceValidation))]
    public partial class service { }

    public class serviceValidation
    {
        [DisplayName("Service Name: ")]
        [Required]
        public string service_name { get; set; }

        [DisplayName("Description: ")]
        [Required]
        public string details { get; set; }

        [DisplayName("Photo: ")]
        [Required]
        public string photo { get; set; }
    }
}