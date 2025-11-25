using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Collections.Specialized.BitVector32;

namespace SWE316HW1MA
{
    // [0]: Summary of (ExcelScheduleLoader) class
    // Reads an Excel schedule by mapping each row into a Section
    internal class ExcelScheduleLoader
    {
        // [1]: Attributes
        private readonly string path;
        private readonly List<string> errors = new List<string>();
        private readonly XLWorkbook workbook;
        private readonly IXLWorksheet worksheet;


        // [2]: Constructors
        public ExcelScheduleLoader(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Excel file path is required.", nameof(path));

            this.path = path;
            workbook = new XLWorkbook(this.path);
            worksheet = workbook.Worksheet(1);
        }

        // [3]: Getters and Setters
        // (No public getters/setters; internal fields are managed within this loader)

        // [4]: Public Methods

        // GetNumberOfRows: Returns data row count (excluding header row).
        public int GetNumberOfRows()
        {
            var last = worksheet.LastRowUsed();
            if (last == null) return 0;

            var idx = last.RowNumber();
            return Math.Max(0, idx - 1);
        }

        // AssignSection: Reads a row and converts it to a Section; returns null if row is empty.
        public Section AssignSection(int rowIndex)
        {
            errors.Clear();
            var row = ReadRow(rowIndex);
            if (IsEmpty(row)) return null;
            return MapRow(row);
        }

        // Close: Disposes workbook resources.
        public void Close()
        {
            workbook?.Dispose();
        }

        // [5]: Helpers

        // ReadRow: Builds a dictionary <Header, CellValue> for a given row index.
        private Dictionary<string, string> ReadRow(int rowIndex)
        {
            var result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            if (worksheet == null) return result;

            var lastCol = worksheet.LastColumnUsed()?.ColumnNumber() ?? 0;
            if (lastCol == 0) return result;

            // Collect headers from first row
            var headers = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            for (int col = 1; col <= lastCol; col++)
            {
                var h = worksheet.Cell(1, col).GetString().Trim();
                if (h.Length > 0 && !headers.ContainsKey(h)) headers[h] = col;
            }

            // Map <header -> value> for this row
            foreach (var kv in headers)
            {
                var v = worksheet.Cell(rowIndex, kv.Value).GetString()?.Trim() ?? string.Empty;
                result[kv.Key] = v;
            }

            return result;
        }

        // IsEmpty: True if all values are empty/whitespace.
        private static bool IsEmpty(Dictionary<string, string> row)
        {
            if (row == null || row.Count == 0) return true;
            foreach (var v in row.Values)
                if (!string.IsNullOrWhiteSpace(v)) return false;
            return true;
        }

        // MapRow: Converts a row dictionary into a Section.
        private Section MapRow(Dictionary<string, string> row)
        {
            // creating course
            row.TryGetValue("COURSE", out var courseCode);
            row.TryGetValue("TITLE", out var courseTitle);
            row.TryGetValue("DEPT", out var dept);
            var course = new Course(courseCode, courseTitle, dept);

            // creating location
            row.TryGetValue("BLDG", out var bldg);
            row.TryGetValue("ROOM", out var room);
            var location = new Location(bldg ?? string.Empty, room ?? string.Empty);

            // creating a sesssion slot
            row.TryGetValue("M_ACT", out var act);
            row.TryGetValue("DAYS1", out var days);
            row.TryGetValue("START1", out var start);
            row.TryGetValue("END1", out var end);
            // parsing -> releated to session slot class
            var dayList = ParseDays(days);
            var startTs = ParseTime(start);
            var endTs = ParseTime(end);
            var activity = ParseActivity(act);

            // creating a section
            row.TryGetValue("TERM", out var term);
            row.TryGetValue("CRN", out var crn);
            row.TryGetValue("SEC", out var sec);
            row.TryGetValue("INSTR", out var instr);

            var section = new Section(crn ?? string.Empty, sec ?? string.Empty, instr ?? string.Empty, term ?? string.Empty, course);

            // one section (same crn and number) can have multiple session slots.
            foreach (var day in dayList)
                section.AddSessionSlot(new SessionSlot(activity, startTs, endTs, day, location));

            return section;
        }

        // ParseDays: Converts a compact day string (e.g., "UMTR") into a list of Weekday values.
        private static List<Weekday> ParseDays(string daysCell)
        {
            var list = new List<Weekday>();
            if (string.IsNullOrWhiteSpace(daysCell)) return list;

            var s = daysCell.Trim().ToLowerInvariant();
            if (s.Length > 7) return list;

            foreach (var ch in s)
            {
                switch (char.ToLowerInvariant(ch))
                {
                    case 'u': list.Add(Weekday.Sun); break;
                    case 'm': list.Add(Weekday.Mon); break;
                    case 't': list.Add(Weekday.Tue); break;
                    case 'w': list.Add(Weekday.Wed); break;
                    case 'r': list.Add(Weekday.Thu); break;
                    case 'f': list.Add(Weekday.Fri); break;
                    case 's': list.Add(Weekday.Sat); break;
                }
            }
            return list;
        }

        // ParseTime: Parses HHMM into TimeSpan.
        private TimeSpan ParseTime(string timeCell)
        {
            if (string.IsNullOrWhiteSpace(timeCell) || timeCell.Length != 4)
            {
                errors.Add("Invalid time '" + timeCell + "'. Expected HHMM.");
                return TimeSpan.Zero;
            }

            if (!int.TryParse(timeCell.Substring(0, 2), out var hh) ||
                !int.TryParse(timeCell.Substring(2, 2), out var mm))
            {
                errors.Add("Invalid time '" + timeCell + "'. Expected numeric HHMM.");
                return TimeSpan.Zero;
            }

            if (hh < 0 || hh > 23 || mm < 0 || mm > 59)
            {
                errors.Add("Invalid time '" + timeCell + "'.");
                return TimeSpan.Zero;
            }

            return new TimeSpan(hh, mm, 0);
        }

        // ParseActivity: Maps activity cell to ActivityType; defaults to NA.
        private ActivityType ParseActivity(string activityCell)
        {
            if (string.IsNullOrWhiteSpace(activityCell))
                return ActivityType.NA;

            var s = activityCell.Trim().ToUpperInvariant();
            if (Enum.TryParse<ActivityType>(s, true, out var parsed))
                return parsed;

            return ActivityType.NA;
        }
    }
}