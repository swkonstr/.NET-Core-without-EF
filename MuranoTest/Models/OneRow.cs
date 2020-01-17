using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuranoTest.Models
{
    public class OneRow
    {
        public string PersonsId { get; set; }
        public string Name { get; set; }        //persons.Name
        public string Age { get; set; }         //persons.Age
        public string City { get; set; }        //persons.City
        public string EmployeesId { get; set; }
        public string Salary { get; set; }      //Employees.Salary
        public string ManagersId { get; set; }
        public string KPI { get; set; }         //Managers.KPI
        public string Bonus { get; set; }       //Managers.Bonus
    }
}
