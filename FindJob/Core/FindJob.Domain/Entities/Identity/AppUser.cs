using Microsoft.AspNetCore.Identity;

namespace FindJob.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        public string NameSurname { get; set; }
        public ICollection<Role> roles { get; set; }

    }


}
