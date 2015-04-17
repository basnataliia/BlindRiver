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
    public partial class careersClass
    {
    }

        [Bind(Exclude="Id")]
    public class careersValidation
    {
        [DisplayName("Title: ")]
        [Required]
        public string title { get; set; }

        [DisplayName("Department: ")]
        [Required]
        public string department { get; set; }

        [DisplayName("Job Description: ")]
        [Required]
        public string description { get; set; }

        [DisplayName("Job Type (full or part time): ")]
        [Required]
        public string jobtype { get; set; }

        [DisplayName("Location: ")]
        [Required]
        public string location { get; set; }

        [DisplayName("Job Code: ")]
        [Required]
        public string jobcode { get; set; }

        
    }
}