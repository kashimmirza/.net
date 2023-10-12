
using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string CreditCardNumber { get; set; }
}

public class DataPuller
{
    public List<Person> PullData(List<Person> data)
    {
        var filteredData = data.Where(person =>
            person.Name == "Kashim" &&
            person.Age == 35 &&
            person.CreditCardNumber.EndsWith("2233")
        ).ToList();

        return filteredData;
    }
}

public class Program
{
    public static void Main()
    {
        // Create a list of people (simulated data source)
        var people = new List<Person>
        {
            new Person { Name = "Kashim", Age = 35, CreditCardNumber = "12342233" },
            new Person { Name = "John", Age = 35, CreditCardNumber = "22337890" },
            new Person { Name = "Kashim", Age = 36, CreditCardNumber = "22330000" },
            new Person { Name = "Kashim", Age = 35, CreditCardNumber = "98772233" },
        };

        // Create a DataPuller instance and use it to filter the data
        var dataPuller = new DataPuller();
        var filteredData = dataPuller.PullData(people);

        // Display the filtered data
        foreach (var person in filteredData)
        {
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, Credit Card: {person.CreditCardNumber}");
        }
    }
}
