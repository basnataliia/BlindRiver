using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace BlindRiver.Models
{

    [MetadataType(typeof(FAQvalidation))]
    public partial class FAQ
    { 
    }

    [Bind(Exclude="id")]
    public class FAQvalidation
    {
        [DisplayName ("Frequently Asked Question: ")]
        [Required]
        public string questions {get; set;}

        [DisplayName ("Answer: ")]
        [Required]
        public string answers {get; set;}
    }
}