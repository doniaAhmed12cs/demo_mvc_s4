using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]

        public string Name { get; set; }
        public string ImageName { get; set; }


        public int? Age { get; set; }


        public string Address { get; set; }


        public string Email { get; set; }


        public string Phone { get; set; }

        public decimal Salary { get; set; }
        public bool IsActive { get; set; }


        public DateTime HireDate { get; set; }


        public DateTime DateOfCreation { get; set; } = DateTime.Now;
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
