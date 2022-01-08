using Framework_Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Framework_Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StoreContext _storeContext;

        public HomeController(ILogger<HomeController> logger, StoreContext storeContext)
        {
            _logger = logger;
            _storeContext = storeContext;
        }

        public IActionResult Index(int soLS)
        {
            var listbook = _storeContext.GetBook(soLS);
            if (listbook != null)
            {
                return View(listbook);
            }
            return View();
            
            
        }



            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
