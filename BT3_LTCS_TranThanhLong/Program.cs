using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT3_LTCS_TranThanhLong
{
    class Program
    {
        public class Department
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public int Salary { get; set; }
            public DateTime Birthday { get; set; }
            public int DepartmentId { get; internal set; }
        }


        static void Main(string[] args)
        {
            var departments = new List<Department>()
            {
                new Department() { Id = 1, Name = "IT" },
                new Department() { Id = 2, Name = "Back-End" },
                new Department() { Id = 3, Name = "SEO" },
            };

                        var employees = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Long", Age = 20, Salary = 10000, Birthday = new DateTime(2000, 7, 13)},
                new Employee() { Id = 2, Name = "Thanh", Age = 25, Salary = 12000, Birthday = new DateTime(1997, 11, 28) },
                new Employee() { Id = 3, Name = "Bon", Age = 42, Salary = 15000, Birthday = new DateTime(1990, 12, 31) },
                new Employee() { Id = 4, Name = "Dung", Age = 30, Salary = 11000, Birthday = new DateTime(1995, 8, 25) },
            };
            // 1. Max, min, average salary
            var salaryStats = employees.Select(e => e.Salary);
            Console.WriteLine($"Max salary: {salaryStats.Max()}");
            Console.WriteLine($"Min salary: {salaryStats.Min()}");
            Console.WriteLine($"Average salary: {salaryStats.Average()}");

            // 2. Join group, join left, join right

            // Join group
            var employeeGroups = employees.GroupBy(e => e.DepartmentId);
            foreach (var group in employeeGroups)
            {
                Console.WriteLine($"Department: {group.Key}");
                foreach (var employee in group)
                {
                    Console.WriteLine($"\t{employee.Name}");
                }
            }

            // Join left
            var leftJoin = employees.Join(departments, e => e.DepartmentId, d => d.Id, (e, d) => new { Employee = e, Department = d });
            foreach (var item in leftJoin)
            {
                Console.WriteLine($"{item.Employee.Name} - {item.Department.Name}");
            }

            // Join right
            var rightJoin = departments.Join(employees, d => d.Id, e => e.DepartmentId, (d, e) => new { Department = d, Employee = e });
            foreach (var item in rightJoin)
            {
                Console.WriteLine($"{item.Department.Name} - {item.Employee.Name}");
            }

            // 3. Max, min age
            var ageStats = employees.Select(e => e.Age);
            Console.WriteLine($"Max age: {ageStats.Max()}");
            Console.WriteLine($"Min age: {ageStats.Min()}");
            Console.ReadLine();
        }
    }
}
