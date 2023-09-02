using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace EmployeeTask.Models
{
    public class Employee
    {
        [Index(0)]
        [Key]
        public string PayyrollNumber { get; set; }

        [Index(1)]
        public string Forename { get; set; }
        [Index(2)]
        public string Surname { get; set; }

        [Index(3)]
        public string DateOfBirth { get; set; }

        [Index(4)]
        public string Telephone { get; set; }

        [Index(5)]
        public string Mobile { get; set; }

        [Index(6)]
        public string Address { get; set; }

        [Index(7)]
        public string Address2 { get; set; }

        [Index(8)]
        public string Postcode { get; set; }

        [Index(9)]
        public string EmailHome { get; set; }

        [Index(10)]
        public string StartDate { get; set; }
    }
}
