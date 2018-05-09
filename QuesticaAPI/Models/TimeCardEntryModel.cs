using System;
using Questica.Model;

namespace QuesticaAPI.Models
{
    public class TimeCardEntryModel
    {
        public string Comments { get; set; }

        public int EmployeeID { get; set; }

        public string EmpNumber { get; set; }

        public string HourClass { get; set; }

        public decimal HourFactor { get; set; }

        public decimal HourRate { get; set; }

        public decimal HourTime { get; set; }

        public int HourType { get; set; }

        public int ProjectID { get; set; }

        public double SpecID { get; set; }

        public DateTime TimeDate { get; set; }

        public int TimeID { get; set; }

        public int? TimePeriodID { get; set; }

        public static implicit operator TimeCardEntryModel(TimeCardEntry soruce)
        {
            return new TimeCardEntryModel
            {
                Comments = soruce.Comments,
                EmpNumber = soruce.EmpNumber,
                EmployeeID = soruce.EmployeeID,
                ProjectID = soruce.ProjectID,
                SpecID = soruce.SpecID,
                TimePeriodID = soruce.TimePeriodID,
                HourClass = soruce.HourClass,
                HourFactor = soruce.HourFactor,
                HourRate = soruce.HourRate,
                HourTime = soruce.HourTime,
                HourType = soruce.HourType,
                TimeDate = soruce.TimeDate,
                TimeID = soruce.TimeID
            };
        }
    }
}