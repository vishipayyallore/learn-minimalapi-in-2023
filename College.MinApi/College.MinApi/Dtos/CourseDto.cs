using System.Text.Json.Serialization;

namespace College.MinApi.Dtos
{

    public class CourseDto
    {
        public Guid CourseId { get; set; } = Guid.NewGuid();

        public string CourseName { get; set; } = string.Empty;

        public int CourseDuration { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public COURSE_TYPE CourseType { get; set; }
    }

    public enum COURSE_TYPE
    {
        ENGINEERING = 1,

        MEDICAL,

        MANAGEMENT
    }

}
