using Microsoft.EntityFrameworkCore.ChangeTracking;
using StudentApi.Contracts;
using StudentApi.Dto;

namespace StudentApi.EFC; 

public class GradeDataAccess : IGradeData {


    private readonly DataAccess _dataAccess;

    public GradeDataAccess(DataAccess dataAccess) {
        _dataAccess = dataAccess;
    }

    public async Task<AddGradeDTO> AddGrade(AddGradeDTO grade) {
        Student? student = await _dataAccess.Students.FindAsync(grade.StudentId);
        if (student == null) {
            throw new Exception("Student not found");
        }
        GradeInCourse gradeInCourse = new() {
            CourseCode = grade.CourseCode,
            Grade = grade.Grade,
        };
        gradeInCourse.Student = student;
        EntityEntry<GradeInCourse> entityEntry = await _dataAccess.Grades.AddAsync(gradeInCourse);
        await _dataAccess.SaveChangesAsync();

        return new AddGradeDTO() {
            CourseCode = entityEntry.Entity.CourseCode,
            Grade = entityEntry.Entity.Grade,
            StudentId = student.Id
        };
    }
}