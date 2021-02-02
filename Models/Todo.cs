using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulingTool.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Beskrivelse")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Minimums Alder")]
        public int RequiredAge { get; set; }
        public ICollection<ShiftTodo> ShiftTodos { get; set; }
    }
}
