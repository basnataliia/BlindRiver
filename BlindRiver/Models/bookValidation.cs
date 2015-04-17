//validation for book an appoinment feature
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

    [MetadataType(typeof(bookAppValidation))]
    public partial class book_app
    { }

    //excluded id from validation as it is auto increment
    [Bind(Exclude = "id")]

    //validation class
    public class bookAppValidation
    {
        //validation for every field in form
        [DisplayName("Name: ")]
        [Required]
        public string name { get; set; }

        [DisplayName("Phone: ")]
        [Required]
        [RegularExpression(@"^\(\d{3}\) ?\d{3}( |-)?\d{4}|^\d{3}( |-)?\d{3}( |-)?\d{4}$")]
        public int phone { get; set; }

        [DisplayName("Email: ")]
        [Required]
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$")]
        public string email { get; set; }

        [DisplayName("Date Of Appointment: ")]
        [Required]
        public DateTime doa { get; set; }

        [DisplayName("Purpose: ")]
        [Required]
        public string purpose { get; set; }
    }
}