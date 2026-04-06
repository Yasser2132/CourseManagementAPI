using Microsoft.EntityFrameworkCore;
using CourseManagementAPI.Data; // This fixes the 'AppDbContext' error
using CourseManagementAPI.Entities;

namespace CourseManagementAPI.Services
{
    public class CourseService
    {
        private readonly AppDbContext _context;
        
        public CourseService(AppDbContext context) 
        { 
            _context = context; 
        }

        public async Task<object> GetCourseListAsync()
        {
            return await _context.Courses
                .AsNoTracking() // Requirement: LINQ Optimization
                .Select(c => new { // Requirement: Projection
                    c.Id,
                    c.Title
                })
                .ToListAsync(); // Requirement: Async
        }
    }
}