using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace BlindRiver.Models
{

    [MetadataType(typeof(SurveyValidation))]
    public partial class Survey
    {
    }

    [Bind(Exclude = "id")]
    public partial class SurveyValidation
    {
        //[DisplayName("Question: ")]
        //[Required]
        //public string Questions { get; set; }

        //[DisplayName("Answer: ")]
        //[Required]
        //public string Answers { get; set; }
    }
}