using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using CourseManagementAPI.Data;     // Points to your Database
using CourseManagementAPI.Entities; // THIS FIXES THE ERROR (Points to Course, Student, etc.)

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly AppDbContext _context;
    public CoursesController(AppDbContext context) { _context = context; }

    [HttpPost]
    [Authorize] // Requirement: Security
    public async Task<IActionResult> CreateCourse(Course course)
{
    _context.Courses.Add(course);
    await _context.SaveChangesAsync(); // Requirement: Async
    return Ok(course);
}

[HttpDelete("{id}")]
[Authorize] // // Requirement: Authorization
public async Task<IActionResult> DeleteCourse(int id)
{
    var course = await _context.Courses.FindAsync(id);
    
    if (course == null)
    {
        return NotFound();
    }

    _context.Courses.Remove(course);
    await _context.SaveChangesAsync(); // Requirement: Async
    
    return NoContent();
}

[HttpGet]
[Authorize]
    public async Task<IActionResult> GetCourses()
    {
        var courses = await _context.Courses
            .AsNoTracking() // Requirement: LINQ Optimization
            .Select(c => new { c.Id, c.Title }) // Requirement: Projection
            .ToListAsync(); // Requirement: Async
        return Ok(courses);
    }
}