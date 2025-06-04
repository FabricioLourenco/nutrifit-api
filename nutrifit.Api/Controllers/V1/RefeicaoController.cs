using Microsoft.AspNetCore.Mvc;

namespace Nutrifit.Api.Controllers.V1
{
    public class RefeicaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
