using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuesticaAPI.Models
{
    public class EmployeeModel
    {
        // Properties
        public decimal EmpBaseHourlyCost { get; set; }

        public string EmpEmail { get; set; }

        public string EmpFirstName { get; set; }

        public string EmpLastName { get; set; }

        public int EmployeeID { get; set; }

        public string EmpNumber { get; set; }

        public string FullName => $"{this.EmpFirstName} {this.EmpLastName}";

        public string UserID { get; set; }

        public string UserName { get; set; }

        public static implicit operator EmployeeModel(Questica.Model.Employee source)
        {
            return new EmployeeModel
            {
                EmpEmail = source.EmpEmail,
                EmpBaseHourlyCost = source.EmpBaseHourlyCost,
                EmpFirstName = source.EmpFirstName,
                EmpLastName = source.EmpLastName,
                EmpNumber = source.EmpNumber,
                EmployeeID = source.EmployeeID,
                UserID = source.UserID,
                UserName = source.UserName
            };
        }
    }
}
