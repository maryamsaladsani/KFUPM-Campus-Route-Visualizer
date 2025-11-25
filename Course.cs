using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE316HW1MA
{
    // [0]: Summary of (Course) class
    // Represents a university course with its code, title, and department.

    internal class Course
    {
        // [1]: Attributes
        private string code;
        private string title;
        private string dept;

        // [2]: Constructors
        public Course() : this(string.Empty, string.Empty, string.Empty) { }

        public Course(string code, string title, string department)
        {
            this.code = code ?? string.Empty;
            this.title = title ?? string.Empty;
            dept = department ?? string.Empty;
        }

        // [3]: Getters and Setters
        public string GetCourseCode() => code;
        public void SetCourseCode(string code) => this.code = code ?? string.Empty;

        public string GetCourseTitle() => title;
        public void SetCourseTitle(string title) => this.title = title ?? string.Empty;

        public string GetDepartment() => dept;
        public void SetDepartment(string department) => dept = department ?? string.Empty;


        // [4]: Methods

        // GetFullName: Combines course code and title for display in area D.
        public string GetFullName() => $"{code} - {title}";
       
    }
}
