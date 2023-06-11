using System.ComponentModel.DataAnnotations;

namespace StudentApi.Dto; 

public class AddGradeDTO {
    [Required, MaxLength(4)]
    public string CourseCode { get; set; }
    [Required]
    public int Grade { get; set; }

    [Required] public int StudentId { get; set; }
}