using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public static class FilterEmployeesQuery
{
    public static string FilterEmployees(IEnumerable<(string Name, int Age, string Department, decimal Salary, DateTime HireDate)> employees)
    {
        if (employees == null || !employees.Any())
        {
            var jsonOptions = new JsonSerializerOptions 
            { 
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping 
            };
            return JsonSerializer.Serialize(new
            {
                Names = new List<string>(),
                TotalSalary = 0m,
                AverageSalary = 0m,
                MinSalary = 0m,
                MaxSalary = 0m,
                Count = 0
            }, jsonOptions);
        }

        var filtered = employees
            .Where(e => e.Age >= 25 && e.Age <= 40)
            .Where(e => e.Department == "IT" || e.Department == "Finance")
            .Where(e => e.Salary >= 5000m && e.Salary <= 9000m)
            .Where(e => e.HireDate > new DateTime(2017, 1, 1))
            .OrderByDescending(e => e.Name.Length)
            .ThenBy(e => e.Name)
            .ToList();

        if (!filtered.Any())
        {
            var jsonOptions2 = new JsonSerializerOptions 
            { 
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping 
            };
            return JsonSerializer.Serialize(new
            {
                Names = new List<string>(),
                TotalSalary = 0m,
                AverageSalary = 0m,
                MinSalary = 0m,
                MaxSalary = 0m,
                Count = 0
            }, jsonOptions2);
        }

        var total = filtered.Sum(e => e.Salary);
        var avg = Math.Round(filtered.Average(e => e.Salary), 2);
        var min = filtered.Min(e => e.Salary);
        var max = filtered.Max(e => e.Salary);
        var names = filtered.Select(e => e.Name).ToList();

        var options = new JsonSerializerOptions 
        { 
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping 
        };

        return JsonSerializer.Serialize(new
        {
            Names = names,
            TotalSalary = total,
            AverageSalary = avg,
            MinSalary = min,
            MaxSalary = max,
            Count = filtered.Count
        }, options);
    }
}
