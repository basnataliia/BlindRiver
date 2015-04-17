using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//this in included for metadatatype
using System.ComponentModel.DataAnnotations;
//include for DisplayName
using System.ComponentModel;
//included for bind
using System.Web.Mvc;

namespace BlindRiver.Models
{
    [MetadataType(typeof(newsValidation))]
    public partial class news_post { }

    public class newsValidation
    {
        [DisplayName("Date: ")]
        [Required]
        public DateTime date { get; set; }

        [DisplayName("Heading: ")]
        [Required]
        public string heading { get; set; }

        [DisplayName("Description: ")]
        [Required]
        public string details { get; set; }

    }
}