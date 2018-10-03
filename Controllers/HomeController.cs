using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSwag.Annotations;

namespace NewApi.Controllers
{
  public class HomeController : Controller
  {
        [SwaggerIgnore]
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
  }
}