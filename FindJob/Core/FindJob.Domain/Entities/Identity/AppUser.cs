using Microsoft.AspNetCore.Identity;

namespace FindJob.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        public string NameSurname { get; set; }
        public ICollection<Role> roles { get; set; }
        public string? Image { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public ICollection<CompanyStaff> Staffs { get; set; }
        public ICollection<PreferredLocation> PreferredLocations { get; set; }


    }


}
