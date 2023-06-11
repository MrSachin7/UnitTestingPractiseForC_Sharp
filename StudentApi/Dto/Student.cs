using System.ComponentModel.DataAnnotations;

namespace StudentApi.Dto; 

public class Student {
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(25)]
    public string Name { get; set; }
    [Required]
    public string Programme { get; set; }

    public ICollection<GradeInCourse>? GradesInCourses { get; set; } = new List<GradeInCourse>();


}