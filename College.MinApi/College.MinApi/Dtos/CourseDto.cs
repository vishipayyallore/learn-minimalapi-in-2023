using System.Text.Json.Serialization;

namespace College.MinApi.Dtos
{

    public class CourseDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string? CourseId { get; set; }

        public string CourseName { get; set; } = string.Empty;

        public int CourseDuration { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public COURSE_TYPE CourseType { get; set; }
    }

}
