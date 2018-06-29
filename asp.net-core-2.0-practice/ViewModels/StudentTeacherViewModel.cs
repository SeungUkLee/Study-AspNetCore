using System;
using System.Collections.Generic;
using asp.netcore2.practice.Models;

namespace asp.netcore2.practice.ViewModels
{
    public class StudentTeacherViewModel
    {
        public Student Student { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
