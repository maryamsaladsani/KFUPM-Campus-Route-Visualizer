# 🗺️ KFUPM Campus Route Visualizer
A Windows Forms application that visualizes student class routes across the KFUPM campus, helping students visualise their daily walking and calculating the approximate distance.

## 📋 Overview

This project was developed as part of **SWE 316: Software Design and Construction** coursework at King Fahd University of Petroleum & Minerals. The application reads course schedule data from Excel files and visualizes the optimal route a student takes between classes on any given day.

### ✨ Key Features

- 📊 **Excel Integration**: Automatically loads and parses term schedule data from Excel files
- 🗓️ **Day-by-Day Visualization**: View your route for any weekday (Sunday-Thursday)
- 📍 **Interactive Campus Map**: Visual representation of buildings with route overlays
- 📏 **Distance Calculation**: Computes total walking distance between classes
- 📈 **Summary Statistics**: Displays number of courses, unique buildings, and travel metrics
- 🎨 **Custom Graphics**: Hand-drawn route visualization using GDI+ (no third-party map components)

## 🖼️ Screenshots

### Main Application Interface
```
┌─────────────────────────────────────────────────────────────┐
│ Enter Student CRN Numbers: [11695 14313 10744 15375]       │
│                                                             │
│  ┌──────────────────────┐    ┌──────────────────────────┐ │
│  │                      │    │      Results             │ │
│  │   Campus Map with    │    │  [U][M][T][W][R]        │ │
│  │   Numbered Route     │    │                          │ │
│  │   Visualization      │    │  Selected Day: Tuesday   │ │
│  │                      │    │  Number of Courses: 4    │ │
│  │   Building Numbers:  │    │  1- SWE 316: Software... │ │
│  │   ① → ② → ③ → ④      │    │  2- SWE 363: Web Eng...│ │
│  │                      │    │  3- ISE 303: Ops Res... │ │
│  │   (Route Lines       │    │  4- STAT201: Prob...    │ │
│  │    Connecting        │    │                          │ │
│  │    Buildings)        │    │  Buildings: 3            │ │
│  │                      │    │  Distance: 780 m         │ │
│  └──────────────────────┘    └──────────────────────────┘ │
└─────────────────────────────────────────────────────────────┘
```

## 🏗️ Architecture

### Class Structure

The application follows **Object-Oriented Design principles** with clear separation of concerns:

#### 📦 Domain Layer
- **`Course`**: Represents a university course (code, title, department)
- **`Section`**: Represents a course section with CRN, instructor, and session slots
- **`SessionSlot`**: Individual class meeting (day, time, location, activity type)
- **`Location`**: Physical classroom location (building + room)

#### 🔧 Service Layer
- **`ExcelScheduleLoader`**: Parses Excel files and maps rows to domain objects
- **`Sections`**: Static repository managing all sections in memory
- **`RouteBuilder`**: Constructs ordered routes based on class times
- **`DistanceCalculator`**: Computes distances between buildings
- **`SummaryReporter`**: Generates textual summaries of routes
- **`BuildingMap`**: Maps building codes to campus coordinates

#### 🎨 Presentation Layer
- **`Visualizer`**: Handles custom map rendering and route drawing
- **`Form1`**: Main UI form coordinating user interactions
- **`Program`**: Application entry point


## 🚀 Getting Started

### Prerequisites

- **Visual Studio 2019 or later**
- **.NET Framework 4.8**
- **Windows OS** (Windows Forms dependency)

### Required NuGet Packages

```xml
- ClosedXML (v0.105.0) - Excel file handling
- DocumentFormat.OpenXml (v3.1.1) - Office file support
- ExcelNumberFormat (v1.1.0) - Excel formatting
- System.Drawing.Common - Graphics rendering
```

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/campus-route-visualizer.git
   cd campus-route-visualizer
   ```

2. **Open the solution**
   ```bash
   start SWE316HW1MA.sln
   ```

3. **Restore NuGet packages**
   - Visual Studio will automatically restore packages on first build
   - Or manually: `Tools` → `NuGet Package Manager` → `Restore NuGet Packages`

4. **Add required assets**
   - Place `CampusMap.png` in `/Assets/` folder
   - Place `TermSchedule251.xlsx` in `/Assets/` folder

5. **Build and run**
   - Press `F5` or click `Start` in Visual Studio

## 📂 Project Structure

```
SWE316HW1MA/
├── Assets/
│   ├── CampusMap.png          # KFUPM campus map image
│   └── TermSchedule251.xlsx   # Term schedule data
├── Domain/
│   ├── Course.cs
│   ├── Section.cs
│   ├── SessionSlot.cs
│   └── Location.cs
├── Services/
│   ├── ExcelScheduleLoader.cs
│   ├── Sections.cs
│   ├── RouteBuilder.cs
│   ├── DistanceCalculator.cs
│   ├── SummaryReporter.cs
│   └── BuildingMap.cs
├── UI/
│   ├── Form1.cs
│   ├── Form1.Designer.cs
│   ├── Visualizer.cs
│   └── ControlExtensions.cs
├── Program.cs
└── SWE316HW1MA.csproj
```

## 💻 Usage

### Basic Workflow

1. **Launch the application**
   - The app automatically loads the term schedule from Excel

2. **Enter CRN numbers**
   - Type your Course Reference Numbers in the input field
   - Format: Space, comma, or semicolon separated (e.g., `11695 14313 10744 15375`)

3. **Select a day**
   - Click one of the day buttons: **U** (Sunday), **M**, **T**, **W**, or **R** (Thursday)

4. **View results**
   - **Map Panel**: Shows your route with numbered stops
   - **Results Panel**: Displays course list, building count, and total distance

### Excel File Format

The application expects an Excel file with these columns:

| Column | Description | Example |
|--------|-------------|---------|
| TERM | Academic term | 202510 |
| CRN | Course Reference Number | 11695 |
| COURSE | Course code | SWE 316 |
| TITLE | Course title | Software Design and Construction |
| DEPT | Department | ISE |
| SEC | Section number | 01 |
| M_ACT | Activity type | LEC |
| DAYS1 | Meeting days (UMTWRF) | MT |
| START1 | Start time (HHMM) | 1300 |
| END1 | End time (HHMM) | 1350 |
| BLDG | Building number | 22 |
| ROOM | Room number | 119 |
| INSTR | Instructor name | JOHN DOE |

## 🧮 Distance Calculation

The application uses pixel-to-meter calibration for distance calculation:

```csharp
private const double MetersPerPixel = 0.25;  // 1 pixel = 0.25 meters
```

Distance between two buildings is calculated using the Euclidean distance formula:

```
distance = √((x₂ - x₁)² + (y₂ - y₁)²) × MetersPerPixel
```

## 🎨 Customization

### Adding New Buildings

Edit `BuildingMap.cs` to add coordinates for new buildings:

```csharp
coords = new Dictionary<string, PointF>
{
    { "1",  new Point(204, 380) },
    { "22", new Point(542, 640) },
    // Add new building here:
    { "99", new Point(600, 500) }
};
```

### Adjusting Visual Style

Modify `Visualizer.cs` constructor to change appearance:

```csharp
routePen = new Pen(Color.LightSkyBlue, 3f);  // Route line color & width
nodeFill = new SolidBrush(Color.DarkBlue);   // Node fill color
labelFont = new Font("Segoe UI", 9f, FontStyle.Bold);  // Label font
```

## 🧪 Testing

### Test Scenarios

1. **Single Course**: Enter one CRN to verify basic functionality
2. **Multiple Courses**: Test with 4-5 CRNs for typical student load
3. **No Classes**: Select a day with no scheduled classes
4. **Invalid CRNs**: Enter non-existent CRNs to test error handling
5. **Different Days**: Verify route changes across different weekdays

### Sample Test Data

```
CRNs: 11695 14313 10744 15375
Expected Buildings (Tuesday): 22 → 63 → 75 → 22
Expected Distance: ~780 meters
```

## 🐛 Known Issues

- Building coordinates are manually approximated and may not be perfectly accurate
- Application requires Windows OS (WinForms dependency)
- Large Excel files (>10,000 rows) may have slower load times
- Map scaling is simple stretch (doesn't maintain aspect ratio perfectly)

## 🔮 Future Enhancements

- [ ] Add building name labels on hover
- [ ] Support for Saturday classes
- [ ] Export route to PDF
- [ ] Calculate optimal schedule based on minimal walking
- [ ] Real-time schedule conflict detection
- [ ] Multi-semester comparison
- [ ] Mobile app version (Xamarin/MAUI)
- [ ] Web-based version (ASP.NET Core + Blazor)

## 📚 Learning Outcomes

This project demonstrates:

- ✅ **OOP Principles**: Encapsulation, abstraction, inheritance
- ✅ **SOLID Principles**: Single Responsibility, Open-Closed
- ✅ **Design Patterns**: Repository, Builder, Strategy
- ✅ **File I/O**: Excel parsing with ClosedXML
- ✅ **Graphics Programming**: Custom drawing with GDI+
- ✅ **Data Structures**: Dictionaries, lists, tuples
- ✅ **Algorithm Design**: Route building, distance calculation
- ✅ **UI/UX Design**: Windows Forms best practices

## 👥 Contributors

- **Maryam Aladsani** (202263480) - Developer

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

**Note**: This is an academic project developed for educational purposes at KFUPM.

⭐ If you find this project helpful, please consider giving it a star!
