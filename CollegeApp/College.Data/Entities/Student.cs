namespace College.Data.Entities
{
    public class Student : BaseEntity
    {
        public string? RollNumber { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime DateofBirth { get; set; }

        public string? Picture { get; set; }
    }

}
