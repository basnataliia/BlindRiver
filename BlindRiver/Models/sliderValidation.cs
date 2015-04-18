using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace BlindRiver.Models
{

    [MetadataType(typeof(sliderValidation))]
    public partial class sliderimage
    {
    }
    //validation class for Image Slider
    [Bind(Exclude = "Id")]
    public class sliderValidation
    {

            [DisplayName("Image Path")]
            [Required]
            public string ImagePath { get; set; }

            [DisplayName("Title")]
            [Required]
            public string Title { get; set; }

            [DisplayName("Description")]
            [Required]
            public string Description { get; set; }

            [DisplayName("Link")]
            [Required]
            public string Link { get; set; }
    }
}