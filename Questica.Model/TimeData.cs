using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Questica.Model
{
    public class TimeData : DbContext
    {
        // Methods
        static TimeData()
        {
            Database.SetInitializer<TimeData>(null);
        }

        public List<AdaptedTimeRecord> LoadTimeCard(Employee employee, TimeCard timeCard)
        {
            List<AdaptedTimeRecord> list = new List<AdaptedTimeRecord>();
            foreach (IGrouping<Objective, TimeCardEntry> grouping in from r in this.TimeCardEntries
                where (r.EmployeeID == employee.EmployeeID) && (r.TimePeriodID == timeCard.TimePeriodID)
                group r by r.Objective)
            {
                AdaptedTimeRecord item = new AdaptedTimeRecord(grouping.First<TimeCardEntry>().Objective, employee);
                foreach (TimeCardEntry entry in grouping)
                {
                    TimeSpan span = (TimeSpan)(entry.TimeDate - timeCard.PayPeriodStartDate);
                    int days = span.Days;
                    item[days] = entry;
                }
                list.Add(item);
            }
            return list;
        }

        // Properties
        public DbSet<Employee> Employees { get; set; }

        public DbSet<HourType> JobCodes { get; set; }

        public DbSet<Objective> Objectives { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<TimeCardEntry> TimeCardEntries { get; set; }

        public DbSet<TimeCard> TimeCards { get; set; }
    }
}