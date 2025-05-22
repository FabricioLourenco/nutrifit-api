using Microsoft.AspNetCore.Mvc;

namespace Nutrifit.Api.Controllers.V1
{
    public class ItemRefeicaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
