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
                new Employee{Name ="Victor W.", DOB = DateTime.Parse("17 April, 1995", new CultureInfo("dk-DK"))},
                new Employee{Name = "Line J.", DOB = DateTime.Parse("18 December, 1994",new CultureInfo("dk-DK"))},
                new Employee{Name = "Emil J.", DOB = DateTime.Parse("13 August, 1999", new CultureInfo("dk-DK"))}
            };
            foreach (var e in employees)
            {
                context.Add(e);
            }
            context.SaveChanges();
            var todos = new Todo[]
            {
                new Todo{Name = "Fyld op i mejeri", RequiredAge = 13},
                new Todo{Name = "Betjene kassen", RequiredAge = 25},
                new Todo{Name = "Optælling af kassen", RequiredAge = 18}
            };
            foreach (var t in todos)
            {
                context.Add(t);
            }
            context.SaveChanges();
        }
    }
}
