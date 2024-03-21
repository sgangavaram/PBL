using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using Microsoft.Data.SqlClient;

namespace SQLRepository
{
    public class StudentData : IStudentData
    {
        private readonly IDbConnection _connection;

        public StudentData(IDbConnection dbConnection)
        {
            _connection = dbConnection;
        }

        public async Task<List<StudentClass>> GetAllStudentsAsync()
        {
            List<StudentClass> student = new List<StudentClass>();
            _connection.Open();
            string query = "select RollNumber, StudentName, Department from StudentTable;";
            SqlCommand command = new SqlCommand(query, (SqlConnection)_connection);

            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    StudentClass studentClass = new StudentClass()
                    {
                        RollNumber = Convert.ToInt32(reader["RollNumber"]),
                        StudentName = Convert.ToString(reader["StudentName"]),
                        Department = Convert.ToString(reader["Department"])
                    };
                    student.Add(studentClass);
                }
            }
            return student;
        }

        public async Task<StudentClass> GetByStudentRollNoAsync(int rollNumber)
        {
            _connection.Open();
            string query = "SELECT RollNumber, StudentName, Department FROM StudentTable WHERE RollNumber = @RollNumber;";
            SqlCommand command = new SqlCommand(query, (SqlConnection)_connection);
            command.Parameters.AddWithValue("@RollNumber", rollNumber);

            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                if (await reader.ReadAsync())
                {
                    return new StudentClass()
                    {
                        RollNumber = Convert.ToInt32(reader["RollNumber"]),
                        StudentName = Convert.ToString(reader["StudentName"]),
                        Department = Convert.ToString(reader["Department"])
                    };
                }
            }
            return null;
        }

        public async Task<bool> UpdateStudentAsync(StudentClass student)
        {
            _connection.Open();
            string query = "UPDATE StudentTable SET StudentName = @StudentName, Department = @Department WHERE RollNumber = @RollNumber;";
            SqlCommand command = new SqlCommand(query, (SqlConnection)_connection);
            command.Parameters.AddWithValue("@RollNumber", student.RollNumber);
            command.Parameters.AddWithValue("@StudentName", student.StudentName);
            command.Parameters.AddWithValue("@Department", student.Department);

            int rowsAffected = await command.ExecuteNonQueryAsync();

            return rowsAffected > 0;
        }

        public async Task<int> InsertStudentAsync(StudentClass student)
        {
            try
            {
                _connection.Open();
                string query = "INSERT INTO StudentTable (RollNumber, StudentName, Department) VALUES (@RollNumber, @StudentName, @Department);";
                SqlCommand command = new SqlCommand(query, (SqlConnection)_connection);
                object rollNumberParam = student.RollNumber != null ? (object)student.RollNumber : DBNull.Value;
                object studentNameParam = !string.IsNullOrEmpty(student.StudentName) ? (object)student.StudentName : DBNull.Value;
                object departmentParam = !string.IsNullOrEmpty(student.Department) ? (object)student.Department : DBNull.Value;
                command.Parameters.AddWithValue("@RollNumber", rollNumberParam);
                command.Parameters.AddWithValue("@StudentName", studentNameParam);
                command.Parameters.AddWithValue("@Department", departmentParam);
                int result = await command.ExecuteNonQueryAsync();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                _connection.Close();
            }
            //return result != null ? Convert.ToInt32(result) : 0;
        }

        public async Task<bool> DeleteStudentAsync(int rollNumber)
        {
            _connection.Open();
            string query = "DELETE FROM StudentTable WHERE RollNumber = @RollNumber;";
            SqlCommand command = new SqlCommand(query, (SqlConnection)_connection);
            command.Parameters.AddWithValue("@RollNumber", rollNumber);

            int rowsAffected = await command.ExecuteNonQueryAsync();

            return rowsAffected > 0;
        }


        public async Task<List<StudentClass2>> GetAllStudentDataAsync()
        {
            List<StudentClass2> student2 = new List<StudentClass2>();
            _connection.Open();
            string query = "select StudentID, StudentName, DOB, Gender from Student;";
            SqlCommand command = new SqlCommand(query, (SqlConnection)_connection);

            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    StudentClass2 studentClass2 = new StudentClass2()
                    {
                        StudentID = Convert.ToInt32(reader["StudentID"]),
                        StudentName = Convert.ToString(reader["StudentName"]),
                        DOB = Convert.ToDateTime(reader["DOB"]),
                        Gender = Convert.ToChar(reader["Gender"])
                    };
                    student2.Add(studentClass2);
                }
            }
            return student2;
        }
    }
}
