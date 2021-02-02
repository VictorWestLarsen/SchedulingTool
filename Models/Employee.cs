using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulingTool.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Navn")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Fødsesdag")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d/M/yyyy}")]
        public DateTime DOB { get; set; }

        public int getAge()
        {
            int age = 0;
            age = DateTime.Now.Year - DOB.Year;
            if (DateTime.Now.DayOfYear < DOB.DayOfYear)
                age = age - 1;

            return age;
        }
    }

}
