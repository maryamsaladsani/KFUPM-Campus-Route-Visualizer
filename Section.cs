using System;
using System.Collections.Generic;
using System.Linq;

namespace SWE316HW1MA
{
    // [0]: Summary of (Section) class
    // Represents a course section.
    internal class Section
    {
        // [1]: Attributes
        private string crn;
        private string number;
        private string instructor;
        private string term;
        private List<SessionSlot> slots;
        private Course course;

        // [2]: Constructors
        public Section()
        {
            crn = string.Empty;
            number = string.Empty;
            instructor = string.Empty;
            term = string.Empty;
            slots = new List<SessionSlot>();
            course = new Course();
        }

        public Section(string crn, string number, string instructor, string term, Course course)
        {
            this.crn = crn ?? string.Empty;
            this.number = number ?? string.Empty;
            this.instructor = instructor ?? string.Empty;
            this.term = term ?? string.Empty;
            this.course = course ?? new Course();
            slots = new List<SessionSlot>();
        }

        // [3]: Getters and Setters
        public string GetCrn() => crn;
        public void SetCrn(string value) => crn = value ?? string.Empty;

        public string GetSectionNumber() => number;
        public void SetSectionNumber(string value) => number = value ?? string.Empty;

        public string GetInstructorName() => instructor;
        public void SetInstructorName(string value) => instructor = value ?? string.Empty;

        public string GetTerm() => term;
        public void SetTerm(string value) => term = value ?? string.Empty;

        public List<SessionSlot> GetSessionSlots() => slots;
        public void SetSessionSlots(List<SessionSlot> value) => slots = value ?? new List<SessionSlot>();

        public Course GetCourse() => course;
        public void SetCourse(Course value) => course = value ?? new Course();

        // [4]: Methods
        // AddSessionSlot: Adds a single session slot to the section.
        public void AddSessionSlot(SessionSlot slot)
        {
            if (slot == null) return;
            slots.Add(slot);
        }

        // HasDay: Returns true if any of the session slots occur on the given weekday.
        public bool HasDay(Weekday day)
        {
            if (slots == null || slots.Count == 0) return false;
            return slots.Any(s => s.GetDay() == day);
        }
    }
}