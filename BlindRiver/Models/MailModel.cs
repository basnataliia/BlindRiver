using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace BlindRiver.Models
{
   
    //class that stores variables to send an email
    public class MailModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }

        [AllowHtml]
        public string Body { get; set; }

    }
}