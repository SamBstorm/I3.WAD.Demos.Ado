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

            //Récupération de l'étudiant 27

            Student stud = service.Get(27);

            Console.WriteLine($"{stud.student_id} {stud.first_name} {stud.last_name}");

            stud.first_name = "Laure";
            stud.last_name = "Romain";
            stud.year_result = 20;
            stud.login = "lromain";
            stud.birth_date = null;

            if (service.Update(27, stud)) Console.WriteLine("Mise à jour effectuée!");
            else Console.WriteLine("Oups! réessayez plus tard!");

            stud = service.Get(27);
            Console.WriteLine($"{stud.student_id} {stud.first_name} {stud.last_name} {stud.birth_date}");
        }
    }
}
