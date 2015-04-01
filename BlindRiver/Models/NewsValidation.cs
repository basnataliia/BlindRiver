using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;
namespace BlindRiver.Models
{
    [MetadataType(typeof(newsValidation))]
    public partial class news_post {}

    public class newsValidation
    {
        [DisplayName("Date: ")]
        [Required]
        public DateTime name { get; set; }

        [DisplayName("Heading: ")]
        [Required]
        public string heading { get; set; }

        [DisplayName("Description: ")]
        [Required]
        public string description { get; set; }
                
    }
}