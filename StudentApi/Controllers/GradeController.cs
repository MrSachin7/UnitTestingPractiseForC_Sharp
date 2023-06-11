using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StudentApi.Contracts;
using StudentApi.Dto;

namespace StudentApi.Controllers; 

[ApiController]
[Route("api/[controller]")]
public class GradeController : ControllerBase {

    private readonly IGradeData _gradeData;

    public GradeController(IGradeData gradeData) {
        _gradeData = gradeData;
    }

    [HttpPost]
    public async Task<ActionResult<AddGradeDTO>> AddGrade(AddGradeDTO grade) {
        AddGradeDTO addedGrade = await _gradeData.AddGrade(grade);
        return Ok(addedGrade);
    }

}