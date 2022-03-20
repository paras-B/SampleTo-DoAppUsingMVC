using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSampleToDoApp.Data;
using YourSampleToDoApp.Models;

namespace YourSampleToDoApp.Controllers
{
    public class TaskCategoryController : Controller
    {
        private readonly ApplicationDBContext _db;

        public TaskCategoryController(ApplicationDBContext db)
        {
            _db = db;
        }
        
        // Get Method
        public IActionResult CreateTask()
        {
            return View();
        }

        //Get Method
        public IActionResult Edit()
        {
            return View();
        }

        // Post Method
         [HttpPost]
         [ValidateAntiForgeryToken]
        public IActionResult Edit(TaskCategory obj)
        {
            if (obj.TaskName == obj.TaskStatus)
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.TaskCategories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(obj);
        }
        
        // Post Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTask(TaskCategory obj)
        {
            if (obj.TaskName == obj.TaskStatus)
            {
                ModelState.AddModelError("Task Name ", "The task status cannot exactly match the task name .");
            }
            if (ModelState.IsValid)
            {
                _db.TaskCategories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(obj);
        }
    }
}
