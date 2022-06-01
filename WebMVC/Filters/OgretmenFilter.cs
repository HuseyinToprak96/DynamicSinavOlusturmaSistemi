using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Filters
{
    public class OgretmenFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string yetki = context.HttpContext.Session.GetString("Yetki");
            if (yetki != "Ogretmen")
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary{
                    {"action","Index" },
                    { "controller","Page"}
                });
            }
            base.OnActionExecuting(context);
        }
    }
}
