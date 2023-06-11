using StudentApi.Dto;

namespace StudentApi.Contracts; 

public interface IStatisticsData {
    Task<StatisticsDto> GetStatistics(string courseCode, bool? totalStudents, bool? totalStudentsPassed, bool? averageGradeOverall, bool? averageGradeOfPassedStudents, bool? medianGrade);
}