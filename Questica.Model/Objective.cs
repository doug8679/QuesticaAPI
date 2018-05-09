using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questica.Model
{
    [Table("tblSpec")]
    public class Objective : IEquatable<Objective>
    {
        // Methods
        public Objective()
        {
            this.Entries = new ObservableListSource<TimeCardEntry>();
        }

        public bool Equals(Objective other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            return (object.ReferenceEquals(this, other) || (this.ProjectID.Equals(other.ProjectID) && this.SpecID.Equals(other.SpecID)));
        }

        public override string ToString() =>
            $"{this.SpecID} - {this.ObjectiveName}";

        // Properties
        [ForeignKey("ProjectID,SpecID")]
        public virtual ObservableListSource<TimeCardEntry> Entries { get; set; }

        [Column("SDescription")]
        public string ObjectiveName { get; set; }

        [ForeignKey("ProjectID")]
        public virtual Project Project { get; set; }

        [Column(Order = 1), Key]
        public int ProjectID { get; set; }

        [NotMapped]
        public Objective Self =>
            this;

        [Key, Column(Order = 2)]
        public double SpecID { get; set; }
    }
}