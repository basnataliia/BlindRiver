using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace BlindRiver.Models
{
    //creating partial class of FAQ
    [MetadataType(typeof(FAQvalidation))]
    public partial class FAQ
    { 
    }

    //Where validation occurs
    [Bind(Exclude="id")]
    public partial class FAQvalidation
    {
        
        [DisplayName ("Frequently Asked Question: ")]
        //FAQ is required
        [Required]
        public string questions {get; set;}

        [DisplayName ("Answer: ")]
        //Answer is required 
        [Required]
        public string answers {get; set;}
    }
}