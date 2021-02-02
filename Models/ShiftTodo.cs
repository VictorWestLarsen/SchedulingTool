using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulingTool.Models
{
    public class ShiftTodo
    {
        public int TodoId { get; set; }
        public Todo Todo { get; set; }
        public int ShiftId { get; set; }
        public Shift Shift { get; set; }
    }
}
