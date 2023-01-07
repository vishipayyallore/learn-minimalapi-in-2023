namespace College.MinApi.Dtos
{

    public class StudentDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string? Name { get; set; } = "No Name";

        public DateTime DateOfBirth { get; set; } = DateTime.UtcNow.AddYears(-6);

        public static IList<StudentDto> GetDummyStudents()
        {
            return new List<StudentDto>()
            {
                new() { Name = "Sri Varu"},
                new() { Name = "Manpreet Sing"},
                new() { Name = "Scott Rudy"},
                new() { Name = "Mohd Azim"}
            };
        }

    }

}
