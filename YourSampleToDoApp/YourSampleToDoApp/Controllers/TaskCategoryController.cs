﻿using Microsoft.AspNetCore.Mvc;
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
                TempData["success"] = "Category updated successfully";
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
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index", "Home");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var TaskCategoryFromDb = _db.TaskCategories.Find(id);
            if(TaskCategoryFromDb == null)
            {
                return NotFound();
            }
            return View(TaskCategoryFromDb);
        }
        
        //Post Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(TaskCategory obj)
        {
            _db.TaskCategories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index", "Home");
        }
    }
}
