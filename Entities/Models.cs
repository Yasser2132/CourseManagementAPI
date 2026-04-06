using System.Collections.Generic;

namespace CourseManagementAPI.Entities
{
    // 1. Instructor Entity
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        // One-to-One Relationship
        public InstructorProfile Profile { get; set; }
        
        // One-to-Many Relationship
        public ICollection<Course> Courses { get; set; }
    }

    // 2. InstructorProfile (One-to-One with Instructor)
    public class InstructorProfile
    {
        public int Id { get; set; }
        public string Bio { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
    }

    // 3. Course (Many-to-Many with Student)
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }

    // 4. Student
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }

    // 5. Enrollment (The Join Table for Many-to-Many)
    public class Enrollment
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}