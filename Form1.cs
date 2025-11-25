using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SWE316HW1MA
{
    // [0]: Summary of (Form1) class : Hosts the UI
    public partial class Form1 : Form
    {

        // [1]: Fields on Form1
        private Visualizer visualizer;
        private BuildingMap buildingMap;
        private RouteBuilder routeBuilder;
        
        // [2]: Constructor
        public Form1()
        {
            InitializeComponent();

            // Load map bitmap once
            string mapPath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,   
            "Assets",
            "CampusMap.png");
            Bitmap map = new Bitmap(mapPath);

            // BuildingMap: provides fixed coordinates for each building.
            buildingMap = new BuildingMap();

            // Visualizer: responsible for drawing the map and route on the panel.
            visualizer = new Visualizer(panelMap, map, buildingMap);
        }

        // [3] Handle button clicks for day selection (Sun, Mon, Tue, etc.)
        private void daysButtonClick(Weekday day)
        {
            // 1. Generate the textual report summary (Area D)
            SummaryReporter summaryReporter = new SummaryReporter(day);

            string crns = crnsTextBox.Text;

            summaryRichTextBox.Text = summaryReporter.GenerateSummary(crns);

            // 2. Prepare data for route visualization: sections having that day are grouped
            List<Section> sections = summaryReporter.FetchSections(SummaryReporter.ParseCrns(crns));

            // 3. Create a RouteBuilder for the selected weekday using the loaded sections.
            routeBuilder = new RouteBuilder(sections, day);

            // 4.  Generate ordered route (sorted by startTime time)
            var ordered = routeBuilder.GetOrderedRouteForCrns(SummaryReporter.ParseCrns(crns));

            // 5. Visualize the ordered route on the campus map
            visualizer.SetRoute(ordered);
        }

        private void buttonU_Click(object sender, EventArgs e) => daysButtonClick(Weekday.Sun);
        private void buttonM_Click_1(object sender, EventArgs e) => daysButtonClick(Weekday.Mon);
        private void buttonT_Click_1(object sender, EventArgs e) => daysButtonClick(Weekday.Tue);
        private void buttonW_Click_1(object sender, EventArgs e) => daysButtonClick(Weekday.Wed);
        private void buttonR_Click_1(object sender, EventArgs e) => daysButtonClick(Weekday.Thu);

       
    }
}
