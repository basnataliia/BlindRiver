﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc.Html;
using System.Web.Mvc;


//namespace Helpers
//{
//    public class HtmlHelper
//    {
//        public static HtmlString NavigationLink(
//       this HtmlHelper html,
//       string linkText,
//       string actionName,
//       string controllerName)
//        {
//            string contextAction = (string)html.ViewContext.RouteData.Values["action"];
//            string contextController = (string)html.ViewContext.RouteData.Values["controller"];

//            bool isCurrent =
//                string.Equals(contextAction, actionName, StringComparison.CurrentCultureIgnoreCase) &&
//                string.Equals(contextController, controllerName, StringComparison.CurrentCultureIgnoreCase);

//            return html.ActionLink(
//                linkText,
//                actionName,
//                controllerName,
//                routeValues: null,
//                htmlAttributes: isCurrent ? new { @class = "current" } : null);
//        }
//    }
//}