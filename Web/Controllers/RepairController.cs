using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class RepairController : Controller
    {
        [HttpGet]
        public IActionResult RaiseNewRepair()
        {
            return View();
        }
    }
}
