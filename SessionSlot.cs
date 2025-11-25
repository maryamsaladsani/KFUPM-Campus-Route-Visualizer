using System;

namespace SWE316HW1MA
{
    // [0]: Summary of (SessionSlot) class
    // Represents one scheduled class meeting with its activity type, timing, day, and location.

    internal enum ActivityType { LEC, COP, LAB, INT, REC, PRJ, SEM, RES, THS, DIS, LLB, EXP, STD, MR, IND, NA }
    internal enum Weekday { Sun, Mon, Tue, Wed, Thu, Fri, Sat }

   
    internal class SessionSlot
    {
        // [1]: Attributes
        private ActivityType activity;
        private TimeSpan startTime;
        private TimeSpan endTime;
        private Weekday day;
        private Location location;


        // [2]: Constructors
        public SessionSlot()
        {
            activity = ActivityType.NA;
            startTime = TimeSpan.Zero;
            endTime = TimeSpan.Zero;
            day = Weekday.Sun;
            location = new Location();
        }

        public SessionSlot(ActivityType activity, TimeSpan startTime, TimeSpan endTime, Weekday day, Location location)
        {
            if (endTime < startTime) throw new ArgumentException("End time must be after startTime time.");
            this.activity = activity;
            this.startTime = startTime;
            this.endTime = endTime;
            this.day = day;
            this.location = location ?? new Location();
        }

        // [3]: Getters and Setters
        public ActivityType GetActivity() => activity;
        public void SetActivity(ActivityType value) => activity = value;

        public TimeSpan GetStartTime() => startTime;
        public void SetStartTime(TimeSpan value)
        {
            if (endTime != TimeSpan.Zero && value > endTime) throw new ArgumentException("Start time cannot be after endTime time.");
            startTime = value;
        }

        public TimeSpan GetEndTime() => endTime;
        public void SetEndTime(TimeSpan value)
        {
            if (value < startTime) throw new ArgumentException("End time must be after startTime time.");
            endTime = value;
        }

        public Weekday GetDay() => day;
        public void SetDay(Weekday value) => day = value;

        public Location GetLocation() => location;
        public void SetLocation(Location value) => location = value ?? new Location();
    }
}
