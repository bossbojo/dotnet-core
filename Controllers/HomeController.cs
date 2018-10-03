using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSwag.Annotations;

namespace AppApi.Controllers
{
    /// <summary>
    /// HomeController is MVC Controller
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// is index page
        /// </summary>
        /// <returns></returns>
        [SwaggerIgnore]
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}