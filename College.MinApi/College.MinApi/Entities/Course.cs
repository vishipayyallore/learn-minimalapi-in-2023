namespace College.MinApi.Entities
{

    public class Course
    {
        public Guid CourseId { get; set; } = Guid.NewGuid();
        
        public string CourseName { get; set; } = string.Empty;
        
        public int CourseDuration { get; set; }
        
        public int CourseType { get; set; }
    }

}
