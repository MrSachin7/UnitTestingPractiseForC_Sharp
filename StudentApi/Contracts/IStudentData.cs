using StudentApi.Dto;

namespace StudentApi.Contracts; 

public interface IStudentData {
    Task<Student> AddStudent(Student student);
    Task<List<Student>> GetStudents();
}