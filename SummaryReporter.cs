using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using static System.Collections.Specialized.BitVector32;

namespace SWE316HW1MA
{
    // [0]: Summary of (SummaryReporter) class
    // Generate a human-readable summary for a selected Weekday based on CRN input string.
    
    internal class SummaryReporter
    {
        // [1]: Attributes 
        private readonly Weekday selectedDay;
        private string crnsText;

        // [2]: Constructor
        public SummaryReporter(Weekday day)
        {
            selectedDay = day;
        }

        // [3]: Getters and Setters

        // [4]: Getting the summary
        public string GenerateSummary(string input)
        {
            // 1. Parse CRNs
            crnsText = input;
            var crns = ParseCrns(crnsText);

            // 2. Get the list of sections for a day based on CRNs passed
            var sections = FetchSections(crns);

            // 3. Pass the list of sections and get the summary
            return BuildSummary(sections);
        }

        // [5]: Helpers
        // ParseCrns: Extracts distinct CRN tokens out of mixed-delimiter text.
        public static List<string> ParseCrns(string crns)
        {
            if (string.IsNullOrWhiteSpace(crns)) return new List<string>();
            return crns
                .Split(new[] { ' ', ',', ';', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .ToList();
        }

        // Fetch sections 
        public List<Section> FetchSections(List<string> crns)
        {
            var result = new List<Section>();
            foreach (var crn in crns)
            {
                var sec = Sections.GetSectionByCrn(crn);
                if (sec != null && sec.HasDay(selectedDay)) result.Add(sec);
            }
            return result;
        }

        // Build the result
        private string BuildSummary(List<Section> sections)
        {
            var sb = new StringBuilder();
            // 1. Selected day
            sb.AppendLine($"Selected Day: {selectedDay}");

            // 2. Number of courses
            sb.AppendLine($"Number of Courses: {sections.Count}");
            
            // 3. Listing the courses
            int idx = 1;
            foreach (var sec in sections)
            {
                sb.AppendLine($"{idx}- {sec.GetCourse().GetFullName()}");
                idx++;
            }

            // 4. Different buildings counter
            sb.AppendLine($"Number of Different Buildings: {Location.CountUniqueBuildings(sections)}");
            
            // 5. Total distance travelled 
            RouteBuilder route = new RouteBuilder(sections, selectedDay);
            sb.AppendLine($"Distance Travelled: " +
                $"{DistanceCalculator.CalculateTotalDistanceMeters(route.GetOrderedRouteForCrns(ParseCrns(crnsText)),new BuildingMap())} m");

            return sb.ToString();
        }  
    }
}
