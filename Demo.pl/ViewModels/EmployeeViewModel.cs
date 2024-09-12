using Demo.DAL.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace Demo.Pl.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Requird!!")]
        [MaxLength(50, ErrorMessage = "Max Length Is  50 Chars")]
        [MinLength(3, ErrorMessage = "Min Length Is 3 Chars")]
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public string ImageName { get; set; }

        [Range(22, 45, ErrorMessage = " Age Must Be In Range From 22 To 45")]
        public int? Age { get; set; }

        [RegularExpression(@"[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{5,10}$",
            ErrorMessage = "Address must be like 123-Street-City-Country")]
        public string Address { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }

        [DisplayName("Hiring Date")]
        public DateTime HireDate { get; set; }
        [DisplayName("Date Of Creation")]


        #region Relation
        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }// Fk
                                              //fK  Optional => OnDelete : Restrict
                                              // Fk Required => On Delete : Cascade
        [InverseProperty("Employees")]
        public Department Department { get; set; }
        // Navigational Property For One
        #endregion
    }
}
