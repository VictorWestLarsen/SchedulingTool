using SchedulingTool.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulingTool.Data
{
    public class DbInitializer
    {
        public static void Initialize(ScheduleContext context)
        {
            context.Database.EnsureCreated();

            if (context.Employees.Any())
            {
                return;
            }

            var employees = new Employee[]
            {
                new Employee{Id = 1, Name ="Victor W.", DOB =DateTime.Parse("17 April, 1995", new CultureInfo("dk-DK"))},
                new Employee{Id = 2, Name = "Line J.", DOB = DateTime.Parse("18 December, 1994",new CultureInfo("dk-DK"))},
                new Employee{Id = 3, Name = "Emil J.", DOB = DateTime.Parse("13 August, 1999", new CultureInfo("dk-DK"))}
            };
            foreach (var e in employees)
            {
                context.Add(e);
            }
            context.SaveChanges();
            var todos = new Todo[]
            {
                new Todo{Id = 1, Name = "Fyld op i mejeri", RequiredAge = 13},
                new Todo{Id = 2, Name = "Betjene kassen", RequiredAge = 25},
                new Todo{Id = 3, Name = "Optælling af kassen", RequiredAge = 18}
            };
            foreach (var t in todos)
            {
                context.Add(t);
            }
            context.SaveChanges();

            var shifts = new Shift[]
            {
                new Shift{Id = 1, EmployeeId = 1, Name = "Morgenvagt", ShiftStart =  DateTime.Parse("1/12/21 07:00"), ShiftEnd = DateTime.Parse("1/12/21 15:00")},
                new Shift{Id = 2, EmployeeId = 2, Name = "Dagsvagt", ShiftStart = DateTime.Parse("1/12/21 10:00"), ShiftEnd = DateTime.Parse("1/12/21 18:00")}
            };
            foreach (var s in shifts)
            {
                context.Add(s);
            }
            context.SaveChanges();
        }
    }
}
