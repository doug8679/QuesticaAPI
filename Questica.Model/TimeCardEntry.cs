using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questica.Model
{
    [Table("tblTimecards")]
    public class TimeCardEntry : IEquatable<TimeCardEntry>
    {
        // Methods
        public TimeCardEntry()
        {
            this.HourFactor = 1M;
            this.HourClass = "Regular";
            this.TimecardCustom1 = "";
            this.TimecardCustom2 = "";
            this.TimecardCustom7 = false;
            this.TimecardCustom8 = false;
            this.Comments = "";
        }

        public bool Equals(TimeCardEntry other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            return (object.ReferenceEquals(this, other) || this.TimeID.Equals(other.TimeID));
        }

        // Properties
        public string Comments { get; set; }

        public virtual Employee Employee { get; set; }

        public int EmployeeID { get; set; }

        public string EmpNumber { get; set; }

        public string HourClass { get; set; }

        public decimal HourFactor { get; set; }

        public decimal HourRate { get; set; }

        public decimal HourTime { get; set; }

        public int HourType { get; set; }

        [ForeignKey("HourType")]
        public virtual HourType JobCode { get; set; }

        [ForeignKey("ProjectID,SpecID")]
        public virtual Objective Objective { get; set; }

        public int ProjectID { get; set; }

        public double SpecID { get; set; }

        [ForeignKey("TimePeriodID")]
        public virtual TimeCard TimeCard { get; set; }

        public string TimecardCustom1 { get; private set; }

        public string TimecardCustom2 { get; private set; }

        public bool TimecardCustom7 { get; private set; }

        public bool TimecardCustom8 { get; private set; }

        public DateTime TimeDate { get; set; }

        [Key]
        public int TimeID { get; set; }

        public int? TimePeriodID { get; set; }
    }
}