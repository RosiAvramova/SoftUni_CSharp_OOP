using System;

namespace P3.Mankind
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] studentArgs = Console.ReadLine().Split();

            string studentFirstName = studentArgs[0];
            string studentLastName = studentArgs[1];
            string facultyNumber = studentArgs[2];


            string[] workerArgs = Console.ReadLine().Split();

            string workerFirstName = workerArgs[0];
            string workerLastName = workerArgs[1];
            double weekSalary = double.Parse(workerArgs[2]);
            double workHoursPerDay = double.Parse(workerArgs[3]);


            try
            {
                Student student = new Student(studentFirstName, studentLastName, facultyNumber);

                Worker worker = new Worker(workerFirstName, workerLastName, weekSalary, workHoursPerDay);

                Console.WriteLine(student);
                Console.WriteLine();
                Console.WriteLine(worker);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
