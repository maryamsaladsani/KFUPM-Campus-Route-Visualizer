using System;
using System.Collections.Generic;
using static System.Collections.Specialized.BitVector32;

namespace SWE316HW1MA
{
    internal static class Sections
    {
        // [0]: Summary of (Sections) class
        // A static utility class that manages all Section objects by CRN.
        // Supports adding, retrieving, and loading sections from an Excel file.

        // [1]: Attributes
        private static readonly Dictionary<string, Section> systemSections =
            new Dictionary<string, Section>(StringComparer.OrdinalIgnoreCase);

        // [2]: Constructors - (Static class — no constructors allowed)

        // [3]: Getters and Setters - (Not applicable — sections are accessed via static methods)

        // [4]: Methods
        // AddSection: Adds a Section or merges its SessionSlots if it already exists.
        public static void AddSection(Section section)
        {
            if (section == null) throw new ArgumentNullException(nameof(section));
            
            // crn - the key of the dictionary
            var crn = section.GetCrn();
            if (string.IsNullOrWhiteSpace(crn)) return;

            // If section already exists, merge its session slots.
            if (systemSections.TryGetValue(crn, out var existing))
            {
                var slots = section.GetSessionSlots();
                if (slots != null)
                    foreach (var slot in slots)
                        existing.AddSessionSlot(slot);
                return;
            }

            // Otherwise, add a new entry.
            systemSections[crn] = section;
        }

        // GetAllSections: Returns all stored sections as a list.
        public static List<Section> GetAllSections() => new List<Section>(systemSections.Values);


        // GetSectionByCrn: Finds a section by its CRN 
        public static Section GetSectionByCrn(string crn)
        {
            if (string.IsNullOrWhiteSpace(crn)) return null; // returns null if crn is not found.
            systemSections.TryGetValue(crn, out var section);
            return section;
        }


        // LoadSections: Reads all sections from the given Excel file and adds them to the collection.
        public static List<Section> LoadSections(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Excel path is required.", nameof(path));

            ExcelScheduleLoader loader = null;
            
            try
            {
                loader = new ExcelScheduleLoader(path);
                var rows = loader.GetNumberOfRows();
                for (int row = 2; row <= rows + 1; row++) // row 1 is the header
                {
                    var sec = loader.AssignSection(row);
                    if (sec != null) AddSection(sec);
                }
                return GetAllSections();
            }
            finally
            {
                loader?.Close();
            }
        }
    }
}
