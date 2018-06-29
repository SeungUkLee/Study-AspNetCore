using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp.netcore2.practice.Models;
using asp.netcore2.practice.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace asp.netcore2.practice.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Teacher> teachers = new List<Teacher>() {
                new Teacher() { Name = "세종대왕", Class = "한글" },
                new Teacher() { Name = "이순신", Class = "해상전략" },
                new Teacher() { Name = "제갈량", Class = "지략" },
                new Teacher() { Name = "을지문덕", Class = "지상전략" }
            };

            var viewModel = new StudentTeacherViewModel()
            {
                Student = new Student(),
                Teachers = teachers
            };

            return View(viewModel);
        }

        // GET: /<controller>/
        public IActionResult Student()
        {
            List<Teacher> teachers = new List<Teacher>() {
                new Teacher() { Name = "세종대왕", Class = "한글" },
                new Teacher() { Name = "이순신", Class = "해상전략" },
                new Teacher() { Name = "제갈량", Class = "지략" },
                new Teacher() { Name = "을지문덕", Class = "지상전략" }
            };

            var viewModel = new StudentTeacherViewModel()
            {
                Student = new Student(),
                Teachers = teachers
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Student(StudentTeacherViewModel model)
        {
            // 유효성 검사
            if (ModelState.IsValid)
            {
                // model 데이터를 Student 테이블에 저장    
            }
            else
            {
                // 에러를 보여준다.
            }

            return View();
        }
    }
}
