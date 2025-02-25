using System;
using System.Collections.Generic;
using System.Linq;

class Department
{
    public string Name { get; set; }
    public string Reg { get; set; }
}

class Employ
{
    public string Name { get; set; }
    public string Department { get; set; }
}

class Program
{
    static void Main()
    {
  
        List<Department> departments = new List<Department>()
        {
            new Department { Name = "Отдел закупок", Reg = "Германия" },
            new Department { Name = "Отдел продаж", Reg = "Испания" },
            new Department { Name = "Отдел маркетинга", Reg = "Испания" }
        };

        List<Employ> employees = new List<Employ>()
        {
            new Employ { Name = "Иванов", Department = "Отдел закупок" },
            new Employ { Name = "Петров", Department = "Отдел закупок" },
            new Employ { Name = "Сидоров", Department = "Отдел продаж" },
            new Employ { Name = "Лямин", Department = "Отдел продаж" },
            new Employ { Name = "Сидоренко", Department = "Отдел маркетинга" },
            new Employ { Name = "Кривоносов", Department = "Отдел продаж" }
        };

        // А) Группировка сотрудников по отделам
        var groupedEmployees = from emp in employees
                               join dept in departments on emp.Department equals dept.Name
                               group emp by dept.Name into g
                               select new
                               {
                                   Department = g.Key,
                                   Employees = g.ToList()
                               };

        Console.WriteLine("Группировка сотрудников по отделам:");
        foreach (var group in groupedEmployees)
        {
            Console.WriteLine($"Отдел: {group.Department}");
            foreach (var emp in group.Employees)
            {
                Console.WriteLine($"  Сотрудник: {emp.Name}");
            }
        }

        // Б) Сотрудники, регион которых начинается на «И»
        var employeesInIRegion = from emp in employees
                                 join dept in departments on emp.Department equals dept.Name
                                 where dept.Reg.StartsWith("И")
                                 select new
                                 {
                                     EmployeeName = emp.Name,
                                     Department = dept.Name,
                                     Region = dept.Reg
                                 };

        Console.WriteLine("\nСотрудники, регион которых начинается на «И»:");
        foreach (var emp in employeesInIRegion)
        {
            Console.WriteLine($"Сотрудник: {emp.EmployeeName}, Отдел: {emp.Department}, Регион: {emp.Region}");
        }
    }
}