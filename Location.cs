using System;
using System.Collections.Generic;
using System.Linq;

namespace SWE316HW1MA
{
    // [0]: Summary of (Location) class
    // Represents the physical place of a section (building and room).

    internal class Location
    {

        // [1]: Attributes
        private string building;
        private string room;

        // [2]: Constructors
        public Location() : this(string.Empty, string.Empty) { }
        public Location(string building, string room)
        {
            this.building = building ?? string.Empty;
            this.room = room ?? string.Empty;
        }

        // [3]: Getters and Setters
        public string GetBuilding() => building;
        public void SetBuilding(string building) => this.building = building ?? string.Empty;

        public string GetRoom() => room;
        public void SetRoom(string room) => this.room = room ?? string.Empty;

        // [4]: Methods
        public static int CountUniqueBuildings(List<Section> sections)
        {
            if (sections == null || sections.Count == 0) return 0;
            var uniqueBuildings = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var section in sections)
            {
                if (section?.GetSessionSlots() == null) continue;

                foreach (var slot in section.GetSessionSlots())
                {
                    var building = slot?.GetLocation()?.GetBuilding();

                    if (!string.IsNullOrWhiteSpace(building))
                        uniqueBuildings.Add(building.Trim());
                }
            }
            return uniqueBuildings.Count;
        }
    }
}