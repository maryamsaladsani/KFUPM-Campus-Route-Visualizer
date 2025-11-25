using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace SWE316HW1MA
{
    public class BuildingMap
    {
        // [1]: Attribute
        // key = building code (e.g. 22) value = (x,y)
        private readonly Dictionary<string, PointF> coords;

        // [2]: Constructor
        public BuildingMap ()
        {
            coords = new Dictionary<string, PointF>
            {
                // Note: coordinates are approximated 
                { "1",      new Point(204, 380) },
                { "3",      new Point(220, 400) },
                { "4",      new Point(259, 360) },
                { "5",      new Point(298, 460) },   
                { "6",      new Point(369, 470) },
                { "7",      new Point(534, 540) },   
                { "9",      new Point(542, 680) },   
                { "10",     new Point(455, 640) },
                { "11",     new Point(518, 840) },
                { "14",     new Point(267, 570) },
                { "15",     new Point(149, 600) },
                { "22",     new Point(542, 640) },
                { "24",     new Point(597, 770) },
                { "28",     new Point( 86, 270) },
                { "39",     new Point(597, 150) },  
                { "42",     new Point(605, 170) },   
                { "57",     new Point(463, 420) },   
                { "58",     new Point(471, 400) },   
                { "59",     new Point(487, 370) },
                { "63",     new Point(408, 290) },   
                { "75",     new Point(408, 310) },   
                { "76",     new Point(267, 490) },
                { "78",     new Point(290, 520) },   
                { "407",    new Point(393, 560) },   
                { "DTV248", new Point(432, 570) }   
            };
        }

        // [3]: Methods
        public PointF GetPointByBuilding(string building)
        {
            if (coords.TryGetValue(building, out PointF point))
                return point;

            // Fail-fast approach: throw if not found
            throw new KeyNotFoundException($"Building '{building}' not found in BuildingMap.");
        }
    }
}
