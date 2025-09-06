using System;
using System.Linq;
using System.Xml.Linq;
using System.Text.Json;
using System.Collections.Generic;

public static class FilterPeopleFromXmlQuery
{
    public static string FilterPeopleFromXml(string xmlData)
    {
        if (string.IsNullOrWhiteSpace(xmlData))
        {
            return JsonSerializer.Serialize(new
            {
                Names = new List<string>(),
                TotalSalary = 0,
                AverageSalary = 0,
                MaxSalary = 0,
                Count = 0
            });
        }

        var xml = XDocument.Parse(xmlData);
        var people = xml.Descendants("Person")
                        .Select(p => new
                        {
                            Name = (string)p.Element("Name"),
                            Age = (int)p.Element("Age"),
                            Department = (string)p.Element("Department"),
                            Salary = (decimal)p.Element("Salary"),
                            HireDate = DateTime.Parse((string)p.Element("HireDate"))
                        })
                        .Where(p => p.Age > 30 &&
                                    p.Department == "IT" &&
                                    p.Salary > 5000 &&
                                    p.HireDate < new DateTime(2019, 1, 1))
                        .OrderBy(p => p.Name)
                        .ToList();

        if (!people.Any())
        {
            return JsonSerializer.Serialize(new
            {
                Names = new List<string>(),
                TotalSalary = 0,
                AverageSalary = 0,
                MaxSalary = 0,
                Count = 0
            });
        }

        var totalSalary = people.Sum(p => p.Salary);
        var averageSalary = Math.Round(people.Average(p => p.Salary), 2);
        var maxSalary = people.Max(p => p.Salary);
        var names = people.Select(p => p.Name).ToList();

        return JsonSerializer.Serialize(new
        {
            Names = names,
            TotalSalary = totalSalary,
            AverageSalary = averageSalary,
            MaxSalary = maxSalary,
            Count = people.Count
        });
    }
}
