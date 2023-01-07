namespace College.MinApi.Dtos
{

    public class StudentDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string? RollNumber { get; set; }

        public string? Name { get; set; } = "No Name";

        public DateTime DateOfBirth { get; set; } = DateTime.UtcNow.AddYears(-6);

        public static IList<StudentDto> GetDummyStudents()
        {
            return new List<StudentDto>()
            {
                new() { RollNumber = "A101", Name = "Sri Varu" },
                new() { RollNumber = "A102", Name = "Manpreet Singh" },
                new() { RollNumber = "A103", Name = "Scott Rudy" },
                new() { RollNumber = "A104", Name = "Mohd Azim" }
            };
        }

    }

}
