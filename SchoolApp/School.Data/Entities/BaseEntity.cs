namespace School.Data.Entities
{

    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public string CreatedBy { get; set; } = "Admin";

        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

        public string ModifiedBy { get; set; } = "Admin";
    }

}