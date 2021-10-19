using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class JobController : Controller
    {
        [HttpGet]
        public IActionResult RaiseNewJob()
        {
            return View();
        }
    }
}
