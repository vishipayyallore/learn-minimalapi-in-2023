using Microsoft.AspNetCore.Identity;

namespace School.Data.Entities
{

    public class SchoolUser : IdentityUser
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTimeOffset? DateOfBirth { get; set; }
    }

}
