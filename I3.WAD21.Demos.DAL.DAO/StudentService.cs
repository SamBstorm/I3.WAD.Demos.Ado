using I3.WAD21.Demos.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace I3.WAD21.Demos.DAL.DAO
{
    public class StudentService
    {
        const string CONN_STRING =@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBSlide;Integrated Security=True";

        public IEnumerable<Student> Get()
        {
            using (SqlConnection connection = new SqlConnection(CONN_STRING))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText =
                        "SELECT student_id, first_name, last_name, birth_date, login, section_id, year_result, course_id FROM student";
                    connection.Open();
                    using (SqlDataReader reader  =command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new Student { 
                                student_id = (int)reader["student_id"],
                                first_name = (string)reader["first_name"],
                                last_name = (string)reader["last_name"],
                                section_id = (int)reader["section_id"],
                                birth_date = (DateTime)reader["birth_date"],
                                login = (string)reader["login"],
                                year_result = (int)reader[nameof(Student.year_result)],
                                course_id = (string)reader[nameof(Student.course_id)]
                            };
                        }
                    }
                }
            }
        }
    }
}
