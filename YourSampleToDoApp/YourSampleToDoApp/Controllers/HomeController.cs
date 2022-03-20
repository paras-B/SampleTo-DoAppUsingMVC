using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using YourSampleToDoApp.Data;
using YourSampleToDoApp.Models;

namespace YourSampleToDoApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDBContext _db;

        public HomeController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<TaskCategory> objTaskCategoryList = _db.TaskCategories;
            Console.WriteLine($"length of list : {objTaskCategoryList.Count()}");
            return View(objTaskCategoryList);
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
