using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolApp
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string StudentId { get; set; }
        public DateTime BirthDate { get; set; }
    }
}