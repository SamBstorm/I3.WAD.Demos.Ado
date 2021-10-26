using I3.WAD21.Demos.DAL.DAO;
using I3.WAD21.Demos.DAL.DTO;
using System;
using System.Collections.Generic;

namespace I3.WAD21.Demos.DAL.Consomation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            StudentService service = new StudentService();

            IEnumerable<Student> students = service.Get();

            foreach (Student student in students)
            {
                Console.WriteLine($"{student.student_id} {student.first_name} {student.last_name}");
            }
        }
    }
}
