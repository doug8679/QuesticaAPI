using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questica.Model
{
    [Table("tblProjects")]
    public class Project : IEquatable<Project>
    {
        // Methods
        public Project()
        {
            this.Objectives = new HashSet<Objective>();
        }

        public bool Equals(Project other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            return (object.ReferenceEquals(this, other) || this.ProjectID.Equals(other.ProjectID));
        }

        public override string ToString() =>
            $"{this.ProjectID} - {this.ProjectName}";

        // Properties
        [ForeignKey("ProjectID")]
        public ICollection<Objective> Objectives { get; private set; }

        public int ProjectID { get; set; }

        [Column("PDescription")]
        public string ProjectName { get; set; }

        public double? PercentComplete { get; set; }

        [Column("PStatus")]
        public string Status { get; set; }

        [NotMapped]
        public Project Self =>
            this;
    }
}