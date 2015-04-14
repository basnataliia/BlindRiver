using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace BlindRiver.Models
{

    [MetadataType(typeof(custompagesValidation))]
    public partial class custompage
    {
    }

    [Bind(Exclude = "Id")]

    public class custompagesValidation
    {
        [DisplayName("Title")]
        [Required]
        public string title { get; set; }

        [DisplayName("body")]
        [Required]
        public string body { get; set; }

        [DisplayName("Image")]
        [Required]
        public string img { get; set; }

        [DisplayName("Published")]
        public string published { get; set; }
    }
}