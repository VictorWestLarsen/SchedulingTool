using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulingTool.Models
{
    public class Shift
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Beskrivelse")]
        public string Name { get; set; }
        [DisplayName("Starttidspunkt")]
        [Required]
        public DateTime ShiftStart { get; set; }
        [DisplayName("Sluttidspunkt")]
        [Required]
        public DateTime ShiftEnd { get; set; }
        [DisplayName("Medarbejder")]
        public int EmployeeId { get; set; }
        public ICollection<ShiftTodo> ShiftTodos { get; set; }

    }
}
