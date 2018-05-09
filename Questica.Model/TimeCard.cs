using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Questica.Model
{
    [Table("tblTimecardHeader")]
    public class TimeCard : IEquatable<TimeCard>
    {
        // Methods
        public TimeCard()
        {
            this.Entries = new HashSet<TimeCardEntry>();
        }

        public bool Equals(TimeCard other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            return (object.ReferenceEquals(this, other) || this.TimePeriodID.Equals(other.TimePeriodID));
        }

        public override string ToString() =>
            $"From {this.PayPeriodStartDate.ToShortDateString()} to {this.PayPeriodEndDate.ToShortDateString()}";

        // Properties
        [ForeignKey("TimePeriodID")]
        public ICollection<TimeCardEntry> Entries { get; private set; }

        public DateTime PayPeriodEndDate { get; set; }

        public DateTime PayPeriodStartDate { get; set; }

        [Key]
        public int TimePeriodID { get; set; }

        public decimal Total =>
            this.Entries.Sum<TimeCardEntry>(((Func<TimeCardEntry, decimal>)(entry => entry.HourTime)));
    }
}