using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StudentApi.Dto; 

public class GradeInCourse {


    [Key] public int Id { get; set; }
    [Required, MaxLength(4)]
    public string CourseCode { get; set; }
    [Required]
    public int Grade { get; set; }

    [JsonIgnore]
    public Student? Student { get; set; }
}