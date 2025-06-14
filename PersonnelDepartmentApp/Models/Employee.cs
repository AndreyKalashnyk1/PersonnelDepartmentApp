﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelDepartmentApp.Models
{
    // Клас для зберігання інформації про співробітника
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FullName => $"{LastName} {FirstName} {MiddleName}";
        public DateTime BirthDate { get; set; }
        public string PassportNumber { get; set; }
        public List<Education> Educations { get; set; } = new List<Education>();
        public int? PositionId { get; set; } 
        public int? DepartmentId { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public decimal Salary { get; set; }
    }

}
