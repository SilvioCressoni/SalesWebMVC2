﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc2.Models
{
    public class Seller
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required !")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required !")]
        [EmailAddress(ErrorMessage = "Enter a valid Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
                           
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} is required !")]
        [Display(Name = "Base Salary")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} Must be from {1} to {2}")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }

        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime inicial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= inicial && sr.Date <= final).Sum(sr => sr.Amount);
        }

    }
}
