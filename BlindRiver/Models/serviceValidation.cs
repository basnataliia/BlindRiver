//validations for service feautre
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//this in included for metadatatype
using System.ComponentModel.DataAnnotations;
//include for DisplayName
using System.ComponentModel;
//included for bind
using System.Web.Mvc;
namespace BlindRiver.Models
{

    [MetadataType(typeof(serviceValidation))]
    public partial class service { }

    //validation class for service 
    public class serviceValidation
    {
        //validation for services forms
        [DisplayName("Service Name: ")]
        [Required]
        public string service_name { get; set; }

        [DisplayName("Description: ")]
        [Required]
        public string details { get; set; }

        [DisplayName("Photo: ")]
        [Required]
        public string photo { get; set; }
    }
}