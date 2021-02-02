using Microsoft.EntityFrameworkCore;
using SchedulingTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulingTool.Data
{
    public class ScheduleContext : DbContext
    {
        public ScheduleContext(DbContextOptions<ScheduleContext> options) : base(options)
        {
        }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shift>().ToTable("Shift");
            modelBuilder.Entity<ShiftTodo>().HasKey(st => new { st.TodoId, st.ShiftId });
            modelBuilder.Entity<ShiftTodo>().HasOne(st => st.Shift).WithMany(s => s.ShiftTodos).HasForeignKey(st => st.ShiftId);
            modelBuilder.Entity<ShiftTodo>().HasOne(st => st.Todo).WithMany(t => t.ShiftTodos).HasForeignKey(st => st.TodoId);
            modelBuilder.Entity<Todo>().ToTable("Todo");
            modelBuilder.Entity<Employee>().ToTable("Employee");
        }
    }
}
