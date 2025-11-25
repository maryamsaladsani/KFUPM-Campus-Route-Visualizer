using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SWE316HW1MA
{
    public static class DistanceCalculator
    {
        // [1]: Attributes
        // Calibration constant — adjust once per map
        private const double MetersPerPixel = 0.25;  // Example: 1 pixel = 0.25 meters

        // [2]: Constructor

        // [3]: Methods
        // distance in meters between two map points
        public static double GetDistanceMeters(PointF a, PointF b)
        {
            double dx = a.X - b.X;
            double dy = a.Y - b.Y;
            double distance = Math.Sqrt(dx * dx + dy * dy);
            return distance * MetersPerPixel;
        }

        // Clculate Total distance 
        public static double CalculateTotalDistanceMeters(
        List<(int Index, string Building)> orderedRoute,
        BuildingMap map)
        {
            if (orderedRoute == null || orderedRoute.Count < 2 || map == null)
                return 0.0;

            double totalMeters = 0.0;
            PointF prevPoint = map.GetPointByBuilding(orderedRoute[0].Building);

            for (int i = 1; i < orderedRoute.Count; i++)
            {
                string building = orderedRoute[i].Building;
                PointF nextPoint = map.GetPointByBuilding(building);

                double segmentMeters = GetDistanceMeters(prevPoint, nextPoint);
                totalMeters += segmentMeters;

                prevPoint = nextPoint;
            }

            return Math.Round(totalMeters,2);
        }
    }
}
