using System.ComponentModel.DataAnnotations;

namespace StudentApi.Dto; 

public class StatisticsDto {
    [Required]
    public string CourseId { get; set; }

    public int? TotalStudents { get; set; }
    public int? TotalStudentsPassed { get; set; }
    public double? AverageGradeOverall { get; set; } 
    public double? AverageGradeOfPassedStudents { get; set; }
    public int? MedianGrade { get; set; }

}