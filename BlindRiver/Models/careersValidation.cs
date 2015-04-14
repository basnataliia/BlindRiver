using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;
namespace BlindRiver.Models
{
    [MetadataType(typeof(careersValidation))]
    public partial class Careers
    {
    }

        [Bind(Exclude="Id")]
    public class careersValidation
    {
        [DisplayName("Title: ")]
        [Required]
        public string title { get; set; }

        
    }
}