﻿namespace College.ApplicationCore.Common
{

    public static class Constants
    {
        public static class HelloWorldEndpoints
        {
            public static string Root { get; } = "/";

            public static string HelloWorld { get; } = "/hw";

            public static string Api { get; } = "/api";

            public static string ApiV1 { get; } = "/api/v1";
        }

        public static class CoursesEndpoints
        {
            public static string Root { get; } = "/api/courses";

            public static string ActionById { get; } = "/api/courses/{Id}";
        }

        public static class StudentsEndpoints
        {
            public static string Root { get; } = "/api/students";

            public static string ActionById { get; } = "/api/students/{Id}";
        }
    }

}
