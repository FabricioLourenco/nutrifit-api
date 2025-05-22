using Microsoft.AspNetCore.Mvc;

namespace Nutrifit.Api.Controllers.V1
{
    public class ConsultaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
