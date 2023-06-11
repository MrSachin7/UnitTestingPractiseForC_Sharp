using Microsoft.EntityFrameworkCore;
using StudentApi.Contracts;
using StudentApi.Dto;

namespace StudentApi.EFC;

public class StatisticsDataAccess : IStatisticsData {
    private readonly DataAccess _dataAccess;

    public StatisticsDataAccess(DataAccess dataAccess) {
        _dataAccess = dataAccess;
    }


    public async Task<StatisticsDto> GetStatistics(string courseCode, bool? totalStudents, bool? totalStudentsPassed,
        bool? averageGradeOverall,
        bool? averageGradeOfPassedStudents, bool? medianGrade) {
        List<GradeInCourse> gradesByCourseId = await _dataAccess.Grades.Include(grades => grades.Student)
            .Where(grade => grade.CourseCode == courseCode).ToListAsync();
        List<Student> studentsByCourse = await _dataAccess.Students
            .Include(student => student.GradesInCourses)
            .Where(student => student.GradesInCourses!
                .Any(grade => grade.CourseCode == courseCode)).ToListAsync();


        int? totalStudentsInCourseValue,
            totalNumberOfStudentsPassedValue,
            averageGradeOverallValue,
            averageGradeByPassedStudentsValue,
            medianGradeValue;
        StatisticsDto statisticsDto = new();
        statisticsDto.CourseId = courseCode;

        // We need to do (totalStudents == true) because totalStudents is nullable
        if (totalStudents == true) {
            statisticsDto.TotalStudents = studentsByCourse.Count;
        }

        if (totalStudentsPassed == true) {
            statisticsDto.TotalStudentsPassed = gradesByCourseId.Count(gradesByCourse => gradesByCourse.Grade >= 2);
        }

        if (averageGradeOverall == true) {
            statisticsDto.AverageGradeOverall = gradesByCourseId.Average(grade => grade.Grade);
        }

        if (averageGradeOfPassedStudents == true) {
            statisticsDto.AverageGradeOfPassedStudents = gradesByCourseId.Where(grade => grade.Grade >= 2)
                .Average(grade => grade.Grade);
        }

        if (medianGrade == true) {
            statisticsDto.MedianGrade = gradesByCourseId.OrderBy(grade => grade.Grade)
                .ElementAt(gradesByCourseId.Count / 2).Grade;
        }

        return statisticsDto;
    }
}