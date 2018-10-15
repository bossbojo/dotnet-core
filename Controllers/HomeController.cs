using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSwag.Annotations;
using WebApi.Services;

namespace AppApi.Controllers
{
    public class HomeController : Controller
    {
         public IActionResult Index()
        {
            ViewData["ENV"] = StaticVariables.ENV;
            ViewData["ProjectName"] = StaticVariables.ProjectName;
            ViewData["Version"] = StaticVariables.Version;
            return View();
        }
        [SwaggerIgnore]
        public IActionResult Swagger()
        {
            return  new RedirectResult("~/swagger");
        }
    }
}