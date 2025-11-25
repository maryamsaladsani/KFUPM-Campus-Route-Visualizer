using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SWE316HW1MA
{
    internal class RouteBuilder
    {
        // [1]: Attributes
        private readonly List<Section> sections;
        private readonly Weekday day;

        // [2]: Constructor
        public RouteBuilder(List<Section> daySections, Weekday day)
        {
            sections = daySections ?? new List<Section>();
            this.day = day;
        }

        // [3]: Methods
        /// Return ordered route (buildings only) for that day.
        public List<(int Index, string Building)> GetOrderedRouteForCrns(List<string> crns)
        {
            List<Section> filteredSections = FilterSectionsByCrnsAndDay(crns);
            List<Section> orderedSections = OrderSectionsByStartTime(filteredSections);
            return ExtractOrderedBuildings(orderedSections);
        }

        // [4]: Helper Methods
        private List<Section> FilterSectionsByCrnsAndDay(List<string> crns)
        {
            List<Section> result = new List<Section>();

            foreach (Section s in sections)
            {
                if (crns.Contains(s.GetCrn()) && s.HasDay(day))
                {
                    result.Add(s);
                }
            }

            return result;
        }

        private List<Section> OrderSectionsByStartTime(List<Section> list)
        {
            list.Sort((a, b) =>
            {
                TimeSpan startA = GetStartTimeForDay(a);
                TimeSpan startB = GetStartTimeForDay(b);
                return startA.CompareTo(startB);
            });

            return list;
        }

        private List<(int Index, string Building)> ExtractOrderedBuildings(List<Section> orderedSections)
        {
            List<(int Index, string Building)> result = new List<(int, string)>();
            int index = 1;

            foreach (Section s in orderedSections)
            {
                string building = GetBuildingForDay(s);
                result.Add((index, building));
                index++;
            }

            return result;
        }
        private TimeSpan GetStartTimeForDay(Section s)
        {
            foreach (SessionSlot slot in s.GetSessionSlots())
            {
                if (slot.GetDay() == day)
                    return slot.GetStartTime();
            }

            return TimeSpan.MinValue;
        }
        private string GetBuildingForDay(Section s)
        {
            foreach (SessionSlot slot in s.GetSessionSlots())
            {
                if (slot.GetDay() == day)
                    return slot.GetLocation().GetBuilding();
            }

            return string.Empty;
        }
    }
}
