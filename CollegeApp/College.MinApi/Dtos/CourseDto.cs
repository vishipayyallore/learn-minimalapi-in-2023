using College.MinApi.Enums;
using System.Text.Json.Serialization;

namespace College.MinApi.Dtos
{

    public record CourseDto
    {
        public Guid Id { get; set; }

        public string? CourseId { get; set; }

        public string? Name { get; set; }

        public int Duration { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public COURSE_TYPE CourseType { get; set; }

        public string? Description { get; set; }
    }

}
