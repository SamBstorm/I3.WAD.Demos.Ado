using System;

namespace I3.WAD21.Demos.DAL.DTO
{
    public class Student
    {
        public int student_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime birth_date { get; set; }
        public string login { get; set; }
        public int section_id { get; set; }
        public int year_result { get; set; }
        public string course_id { get; set; }
    }
}
