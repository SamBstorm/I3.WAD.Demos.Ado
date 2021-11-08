using I3.WAD21.Demos.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
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
                            yield return Convert(reader);
                        }
                    }
                }
            }
        }

        public Student Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONN_STRING))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.Parameters.AddWithValue("stu_id",id);
                    command.CommandText =
                        $"SELECT student_id, first_name, last_name, birth_date, login, section_id, year_result, course_id FROM student WHERE student_id = @stu_id";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) return Convert(reader);
                        return null;
                    }
                }
            }
        }

        public int Insert(Student entity)
        {
            using(SqlConnection connection = new SqlConnection(CONN_STRING))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    SqlParameter p_fn = new SqlParameter() { ParameterName = "fn", Value = entity.first_name };
                    SqlParameter p_ln = new SqlParameter() { ParameterName = "ln", Value = entity.last_name };
                    SqlParameter p_bd = new SqlParameter() { ParameterName = "bd", Value = entity.birth_date };
                    SqlParameter p_lg = new SqlParameter() { ParameterName = "lg", Value = entity.login };
                    SqlParameter p_yr = new SqlParameter() { ParameterName = "yr", Value = entity.year_result };
                    SqlParameter p_sid = new SqlParameter() { ParameterName = "sid", Value = entity.section_id };
                    SqlParameter p_cid = new SqlParameter() { ParameterName = "cid", Value = entity.course_id };
                    command.Parameters.Add(p_fn);
                    command.Parameters.Add(p_ln);
                    command.Parameters.Add(p_bd);
                    command.Parameters.Add(p_lg);
                    command.Parameters.Add(p_yr);
                    command.Parameters.Add(p_sid);
                    command.Parameters.Add(p_cid);
                    command.CommandText = "INSERT INTO Student (first_name, last_name, birth_date, year_result, login, section_id, course_id) OUTPUT inserted.student_id VALUES (@fn, @ln, @bd, @yr, @lg, @sid, @cid)";
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public bool Update(int id, Student entity)
        {
            using (SqlConnection connection = new SqlConnection(CONN_STRING))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    SqlParameter p_fn = new SqlParameter() { ParameterName = "fn", Value = entity.first_name };
                    SqlParameter p_ln = new SqlParameter() { ParameterName = "ln", Value = entity.last_name };
                    SqlParameter p_bd = new SqlParameter() { ParameterName = "bd", Value = entity.birth_date };
                    SqlParameter p_lg = new SqlParameter() { ParameterName = "lg", Value = entity.login };
                    SqlParameter p_yr = new SqlParameter() { ParameterName = "yr", Value = entity.year_result };
                    SqlParameter p_sid = new SqlParameter() { ParameterName = "sid", Value = entity.section_id };
                    SqlParameter p_cid = new SqlParameter() { ParameterName = "cid", Value = entity.course_id };
                    SqlParameter p_stu_id = new SqlParameter() { ParameterName = "stu_id", Value = id };
                    command.Parameters.Add(p_fn);
                    command.Parameters.Add(p_ln);
                    command.Parameters.Add(p_bd);
                    command.Parameters.Add(p_lg);
                    command.Parameters.Add(p_yr);
                    command.Parameters.Add(p_sid);
                    command.Parameters.Add(p_cid);
                    command.Parameters.Add(p_stu_id);
                    command.CommandText = "UPDATE student SET first_name = @fn, last_name = @ln, birth_date = @bd, login = @lg, year_result = @yr , section_id = @sid, course_id = @cid WHERE student_id = @stu_id";
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONN_STRING))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    SqlParameter p_stu_id = new SqlParameter() { ParameterName = "stu_id", Value = id };
                    command.Parameters.Add(p_stu_id);
                    command.CommandText = "DELETE FROM student WHERE student_id = @stud_id";
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        //La méthode Convert permet de convertir les résultat des IDataRecord vers l'objet Student
        //Attention que l'objet Student à des propriétés nullable
        private Student Convert(IDataRecord reader)
        {
            return new Student
            {
                student_id = (int)reader["student_id"],
                first_name = (reader["first_name"] is DBNull) ? null : (string)reader["first_name"],
                last_name = (reader["last_name"] is DBNull) ? null : (string)reader["last_name"],
                section_id = (reader["section_id"] is DBNull) ? null : (int?)reader["section_id"],
                birth_date = (reader["birth_date"] is DBNull) ? null : (DateTime?)reader["birth_date"],
                login = (reader["login"] is DBNull) ? null : (string)reader["login"],
                year_result = (reader["year_result"] is DBNull) ? null : (int?)reader[nameof(Student.year_result)],
                course_id = (string)reader[nameof(Student.course_id)]
            };
        }
    }
}
