using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace BlindRiver.Models
{
    [MetadataType(typeof(HomepageModuleValidation))]
    public partial class homemodules
    {
    }

    [Bind(Exclude="id")]
    public class HomepageModuleValidation
    {
        [DisplayName("Image Path")]
        [Required]
        public string imagePath { get; set; }

        [DisplayName("Link URL")]
        [Required]
        public string linkURL { get; set; }

        [DisplayName("Description")]
        [Required]
        public string description { get; set; }

        [DisplayName("Link Name")]
        [Required]
        public string linkName { get; set; }
    }
}