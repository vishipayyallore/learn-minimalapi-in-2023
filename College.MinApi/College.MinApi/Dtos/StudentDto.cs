namespace College.MinApi.Dtos
{

    public class StudentDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string? Name { get; set; } = "No Name";

        public DateTime DateOfBirth { get; set; } = DateTime.UtcNow.AddYears(-6);
    }

}
