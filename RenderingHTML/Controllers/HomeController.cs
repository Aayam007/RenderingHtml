/*
 * CONTROLLER: Handles HTTP requests, interacts with models, and returns views.
 * Each public method is an ACTION mapped to a URL route.
 *
 * MODEL BINDING:
 *   ASP.NET MVC automatically maps incoming HTTP data (route values, query strings,
 *   form fields) to action method parameters or model properties.
 *   The field/parameter name must match the model property name exactly.
 *   Example: a form input named "Name" binds to Student.Name automatically.
 *
 * [HttpPost]:
 *   Restricts an action to handle only HTTP POST requests (form submissions).
 *   Without it the action responds to all HTTP verbs.
 *
 * [ValidateAntiForgeryToken]:
 *   Verifies the hidden CSRF token that Tag Helpers inject into every <form>.
 *   Prevents cross-site request forgery attacks.
 *
 * ModelState.IsValid:
 *   True only when ALL Data Annotation validation rules on the bound model pass.
 *   If any [Required], [Range], [StringLength] etc. rule fails, this is false
 *   and we return the same view so the user can see the error messages.
 */

using Microsoft.AspNetCore.Mvc;
using RenderingHTML.Models;
using System.Collections.Generic;

namespace RenderingHTML.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var students = new List<Student>
            {
                new Student { Id = 1, Name = "Ram",  Course = "MIT", Age = 25 },
                new Student { Id = 2, Name = "Sita", Course = "BCA", Age = 22 },
                new Student { Id = 3, Name = "Hari", Course = "BIM", Age = 24 }
            };

            return View(students);
        }

        public IActionResult Details(int id)
        {
            var student = new Student { Id = id, Name = "Ram", Course = "MIT", Age = 25 };
            return View(student);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View(student);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
