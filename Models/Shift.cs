using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulingTool.Models
{
    public class Shift
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d/M/yyyy HH:mm}")]
        public DateTime ShiftStart { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d/M/yyyy HH:mm}")]
        public DateTime ShiftEnd { get; set; }
        public int EmployeeId { get; set; }

        public ICollection<Todo> Todos { get; set; }

    }
}
