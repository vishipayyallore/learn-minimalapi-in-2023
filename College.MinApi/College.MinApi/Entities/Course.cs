namespace College.MinApi.Entities
{

    public class Course : BaseEntity
    {
        public string? CourseId { get; set; }

        public string? Name { get; set; }

        public int Duration { get; set; }

        public int CourseType { get; set; }

        public string? Description { get; set; }
    }

}
