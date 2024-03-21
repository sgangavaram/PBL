using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using SQLRepository;

namespace StudentManagementService
{
    public class StudentService: IStudentService
    {
        private readonly IStudentData _studentData;

        public StudentService(IStudentData studentData)
        {
            _studentData = studentData;
        }


        public async Task<List<StudentClass>> GetAllStudents()
        {
            return await _studentData.GetAllStudentsAsync();
        }

        public async Task<StudentClass> GetByStudentRollNo(int rollNo)
        {
            return await _studentData.GetByStudentRollNoAsync(rollNo);
        }

        public async Task<int> InsertStudent(StudentClass student)
        {
            return await _studentData.InsertStudentAsync(student);
        }

        public async Task<bool> UpdateStudent(StudentClass student)
        {
            return await _studentData.UpdateStudentAsync(student);
        }

        public async Task<bool> DeleteStudent(int rollNo)
        {
            return await _studentData.DeleteStudentAsync(rollNo);
        }

        public async Task<List<StudentClass2>> GetAllStudentData()
        {
            return await _studentData.GetAllStudentDataAsync();
        }
    }
}

