using StudentApi.Dto;

namespace StudentApi.Contracts; 

public interface IGradeData {
    Task<AddGradeDTO> AddGrade(AddGradeDTO grade);
}