﻿using System.Text.Json.Serialization;
using College.MinApi.Enums;

namespace College.MinApi.Dtos
{

    public class CourseDto
    {
        public string? CourseId { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Duration { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public COURSE_TYPE CourseType { get; set; }

        public string? Description { get; set; }
    }

}
