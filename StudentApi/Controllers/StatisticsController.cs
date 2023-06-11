using Microsoft.AspNetCore.Mvc;
using StudentApi.Contracts;
using StudentApi.Dto;

namespace StudentApi.Controllers; 

[ApiController]
[Route("api/[controller])")]
public class StatisticsController : ControllerBase {


    private readonly IStatisticsData _statisticsData;

    public StatisticsController(IStatisticsData statisticsData) {
        _statisticsData = statisticsData;
    }

    [HttpGet]
    public async Task<ActionResult<StatisticsDto>> GetStatistics([FromQuery] string? courseCode,[FromQuery] bool? totalStudents,
        [FromQuery] bool? totalStudentsPassed, [FromQuery] bool? averageGradeOverall,
        [FromQuery] bool? averageGradeOfPassedStudents, [FromQuery] bool? medianGrade) {
        try {
            if (courseCode == null) {
                return StatusCode(500, "Course code is required");
            
            }

            StatisticsDto statistics = await _statisticsData.GetStatistics(courseCode
                , totalStudents, totalStudentsPassed, averageGradeOverall, averageGradeOfPassedStudents, medianGrade);
            return Ok(statistics);
        }
        catch (Exception e) {
           return  StatusCode(500, e.Message);
        }

    }

}