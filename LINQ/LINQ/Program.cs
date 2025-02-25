using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Person
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public int Age { get; set; }
    public double Weight { get; set; }

    public override string ToString()
    {
        return $"{LastName} {FirstName} {MiddleName}, Возраст: {Age}, Вес: {Weight} кг";
    }
}

class Program
{
    static void Main()
    {

        string filePath = "B:\\nowalg\\LINQ\\rabota.txt.txt";

        var lines = File.ReadAllLines(filePath);
        var people = new List<Person>();
        foreach (var line in lines)
        {
            try
            {
                var parts = line.Split(' ');
                if (parts.Length < 5)
                {
                    Console.WriteLine($"Пропущена строка: {line} (недостаточно данных)");
                    continue;
                }
                var person = new Person
                {
                    LastName = parts[0],
                    FirstName = parts[1],
                    MiddleName = parts[2],
                    Age = int.Parse(parts[3]),
                    Weight = double.Parse(parts[4])
                };
                people.Add(person);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обработке строки: {line}. {ex.Message}");
            }
        }

        var youngPeople = people.Where(p => p.Age < 40).ToList();
        Console.WriteLine("Люди младше 40 лет:");
        foreach (var person in youngPeople)
        {
            Console.WriteLine(person);
        }
    }
}