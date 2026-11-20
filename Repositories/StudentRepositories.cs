using Microsoft.Ajax.Utilities;
using Student_Database_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Student_Database_Management_System.Repositories
{
    public class StudentRepositories
    {

        private readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString); 


        //GET STUDENTS
        public List<Student> GetAllStudents()
        {

            List<Student> students = new List<Student>();

            SqlCommand cmd = new SqlCommand("crud", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@action", "get");

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            adapter.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                students.Add(new Student
                {
                    ID = Convert.ToInt32(row["ID"]),
                    Name = Convert.ToString(row["Name"]),
                    Age = Convert.ToInt32(row["Age"]),
                    Email = Convert.ToString(row["Email"]),
                    City = Convert.ToString(row["City"]),
                });
            }

            return students;
        }


        //ADD STUDENT
        public bool AddStudent(Student student)
        {

            SqlCommand cmd = new SqlCommand("crud", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@action", "add");
            cmd.Parameters.AddWithValue("@name", student.Name);
            cmd.Parameters.AddWithValue("@age", student.Age);
            cmd.Parameters.AddWithValue("@email", student.Email);
            cmd.Parameters.AddWithValue("@city", student.City);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            return cmd.ExecuteNonQuery() > 0;

        }

        //UPDATE STUDENT
        public bool UpdateStudent(Student student)
        {

            SqlCommand cmd = new SqlCommand("crud", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@action", "update");
            cmd.Parameters.AddWithValue("@id", student.ID);
            cmd.Parameters.AddWithValue("@name", student.Name);
            cmd.Parameters.AddWithValue("@age", student.Age);
            cmd.Parameters.AddWithValue("@email", student.Email);
            cmd.Parameters.AddWithValue("@city", student.City);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            return cmd.ExecuteNonQuery() > 0;

        }

        //DELETE STUDENT
        public bool DeleteStudent(Student student)
        {

            SqlCommand cmd = new SqlCommand("crud", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@action","delete");
            cmd.Parameters.AddWithValue("@id", student.ID);
          

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            return cmd.ExecuteNonQuery() > 0;

        }

        //GET STUDENTSBYID
        public Student GetStudentByID(int id)
        {

            Student student = null;

            SqlCommand cmd = new SqlCommand("crud", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@action", "getbyID");
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            adapter.Fill(dt);

           
            student = new Student
            {   
                ID = (int)dt.Rows[0]["Id"],
                Name = dt.Rows[0]["Name"].ToString(),
                Age = (int)dt.Rows[0]["Age"],
                Email = dt.Rows[0]["Email"].ToString(),
                City = dt.Rows[0]["City"].ToString()
            };
            

            return student;
        }

    }
}