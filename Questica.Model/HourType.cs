using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questica.Model
{
    [Table("tlkpHourTypes")]
    public class HourType : IEquatable<HourType>
    {
        // Methods
        public HourType()
        {
            this.Entries = new HashSet<TimeCardEntry>();
        }

        public bool Equals(HourType other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            return (object.ReferenceEquals(this, other) || this.PKHourType.Equals(other.PKHourType));
        }

        public override string ToString() =>
            this.HourDescription;

        // Properties
        public string EarningNumber { get; set; }

        [ForeignKey("PKHourType")]
        public virtual ICollection<TimeCardEntry> Entries { get; set; }

        public bool Exported { get; set; }

        public bool HourActive { get; set; }

        public string HourClass { get; set; }

        public decimal? HourCost { get; set; }

        public string HourDescription { get; set; }

        [Column("HourType"), Key]
        public int PKHourType { get; set; }
    }
}