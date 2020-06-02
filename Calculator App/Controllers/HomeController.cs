using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CalculatorApp.Models;

namespace CalculatorApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index(Calculator calculator)
        {
            return View(calculator);
        }
        [HttpPost]
        public IActionResult Calculate(Calculator calculator)
        {
            calculator.CalculateResult();

            return RedirectToAction("Index", calculator);
        }

    }
}
