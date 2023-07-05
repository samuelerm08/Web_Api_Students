using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiStudents.Models
{    
    public class Student
    {       
        public int StudentId { get; set; }
        [Column(TypeName = "varchar(30)")]
        [Required(ErrorMessage = "Field required!")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(30)")]
        [Required(ErrorMessage = "Field required!")]
        public string LastName { get; set; }
        [Column(TypeName = "varchar(30)")]
        [Required(ErrorMessage = "Field required!")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Field required!")]
        public int Grade { get; set; }
        [Required(ErrorMessage = "Field required!")]
        public int DNI { get; set; }
        [Column(TypeName = "date")]
        [Required(ErrorMessage = "Field required!")]
        public DateTime BornDate { get; set; }        
    }
}
