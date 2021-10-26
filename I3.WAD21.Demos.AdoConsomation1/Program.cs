using I3.WAD.Demos.Adolibrary;
using System;

namespace I3.WAD21.Demos.AdoConsomation1
{
    class Program
    {
        static void Main(string[] args)
        {
            Student stu = new Student()
            {
                First_Name = "Samuel",
                Last_Name = "Legrain",
                Id = 1
            };
            Console.WriteLine($"{stu.Id} {stu.First_Name} {stu.Last_Name}");
        }
    }
}
