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

            Console.WriteLine("LISTE ETUDIANTS \n-------------");
            IEnumerable<Student> students = service.Get();

            foreach (Student student in students)
            {
                Console.WriteLine($"{student.student_id} {student.first_name} {student.last_name}");
            }

            Console.WriteLine("JUSTE ETUDIANT 12\n-------------");

            Student stud = service.Get(12);

            Console.WriteLine($"{stud.student_id} {stud.first_name} {stud.last_name}");

            Console.WriteLine("JUSTE ETUDIANT 26\n-------------");

            stud = service.Get(26);

            if (stud != null) Console.WriteLine($"{stud.student_id} {stud.first_name} {stud.last_name}");
        }
    }
}
