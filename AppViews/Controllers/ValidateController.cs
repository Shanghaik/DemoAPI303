using Microsoft.AspNetCore.Mvc;

namespace AppViews.Controllers
{
    public class ValidateController : Controller
    {
        public IActionResult Create()
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            else return BadRequest(ModelState);
            return View();
        }
    }
}
