using Microsoft.AspNetCore.Mvc;

namespace Nutrifit.Api.Controllers.V1
{
    public class PlanoAlimentarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
