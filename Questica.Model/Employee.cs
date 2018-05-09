using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questica.Model
{
    [Table("tblEmployee")]
    public class Employee : IEquatable<Employee>
    {
        // Methods
        public Employee()
        {
            this.Entries = new HashSet<TimeCardEntry>();
        }

        public bool Equals(Employee other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            return (object.ReferenceEquals(this, other) || this.EmployeeID.Equals(other.EmployeeID));
        }

        public override string ToString() =>
            $"{this.EmpFirstName} {this.EmpLastName}, ID: {this.EmployeeID}, Number: {this.EmpNumber}";

        // Properties
        public decimal EmpBaseHourlyCost { get; set; }

        public string EmpEmail { get; set; }

        public string EmpFirstName { get; set; }

        public string EmpLastName { get; set; }

        [Key]
        public int EmployeeID { get; set; }

        public string EmpNumber { get; set; }

        [ForeignKey("EmployeeID")]
        public virtual ICollection<TimeCardEntry> Entries { get; set; }

        [NotMapped]
        public string FullName =>
            $"{this.EmpFirstName} {this.EmpLastName}";

        public byte[] Password { get; private set; }

        public string UserID { get; set; }

        public string UserName { get; set; }
    }
}
