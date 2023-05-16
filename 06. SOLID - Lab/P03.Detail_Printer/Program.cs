using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            IList<Employee> employees = new List<Employee>();

            Employee employee = new Employee("Petar");
            employees.Add(employee);

            ICollection<string> list = new List<string> { "firstText", "secondText", "thirdText" };
            Employee menager = new Manager("Georgi", list);
            employees.Add(menager);

            DetailsPrinter detailsPrinter = new DetailsPrinter(employees);
            detailsPrinter.PrintDetails();
        }
    }
}
