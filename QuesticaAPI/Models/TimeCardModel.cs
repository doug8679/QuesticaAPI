using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questica.Model;

namespace QuesticaAPI.Models
{
    public class TimeCardModel
    {
        public TimeCardModel()
        {
            Entries = new List<TimeCardEntryModel>();
        }

        public ICollection<TimeCardEntryModel> Entries { get; set; }

        public DateTime PayPeriodEndDate { get; set; }

        public DateTime PayPeriodStartDate { get; set; }

        public int TimePeriodID { get; set; }

        public static implicit operator TimeCardModel(TimeCard source)
        {
            var result = new TimeCardModel
            {
                PayPeriodEndDate = source.PayPeriodEndDate,
                PayPeriodStartDate = source.PayPeriodStartDate,
                TimePeriodID = source.TimePeriodID
            };
            foreach (var entry in source.Entries)
            {
                result.Entries.Add(entry);
            }

            return result;
        }
    }

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
