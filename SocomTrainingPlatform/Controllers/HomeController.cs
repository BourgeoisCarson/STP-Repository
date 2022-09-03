using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using SocomTrainingPlatform.BuisnessLogic;
using SocomTrainingPlatform.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly SocomTrainingPlatformContext _context;
        private readonly SiteSearchLogic searchLogic;

        public HomeController(SocomTrainingPlatformContext context, ILogger<HomeController> logger)
        {
            _context = context;
            searchLogic = new SiteSearchLogic(context);
            _logger = logger;
        }


        public IActionResult Index()
        {
            ViewData["City"] = searchLogic.GetStateCity().Select(s => new SelectListItem { Value = s.Id, Text = s.State }).ToList();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
