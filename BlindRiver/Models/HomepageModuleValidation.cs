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
    public partial class homemodule
    {
    }

    //validation class fror hompage modules
    [Bind(Exclude="id")]
    public class HomepageModuleValidation
    {
        [DisplayName("Image Path")]    
        public string image_path { get; set; }

        [DisplayName("Link URL")]
        [Required]
        public string link_url { get; set; }

        [DisplayName("Description")]
        [Required]
        public string description { get; set; }

        [DisplayName("Link Name")]
        [Required]
        public string link_name { get; set; }
    }
}