using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace BlindRiver.Models
{
    [MetadataType(typeof(linksmenuValidation))]
    public partial class mainmenulink
    {
    }

    //validatin class for menu links
    public class linksmenuValidation
    {
        [Bind(Exclude = "id")]
        public class contactsValidation
        {
            [DisplayName("Link Name")]
            [Required]
            public string link_name { get; set; }

            [DisplayName("Link URL")]
            [Required]
            public string link_url { get; set; }

            [DisplayName("Parent ID")]
            public string parent_id { get; set; }
        }
    }
}