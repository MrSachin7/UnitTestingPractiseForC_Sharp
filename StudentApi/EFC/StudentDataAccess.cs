using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StudentApi.Contracts;
using StudentApi.Dto;

namespace StudentApi.EFC;

public class StudentDataAccess : IStudentData {
    private readonly DataAccess _dataAccess;

    public StudentDataAccess(DataAccess dataAccess) {
        _dataAccess = dataAccess;
    }


    public async Task<Student> AddStudent(Student student) {
        EntityEntry<Student> entityEntry = await _dataAccess.Students.AddAsync(student);
        await _dataAccess.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async Task<List<Student>> GetStudents() {
        return await _dataAccess.Students
            .Include(student => student.GradesInCourses).ToListAsync();
    }
}