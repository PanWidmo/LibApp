using System;

namespace LibApp.Dtos
{
    public class CustomerUpdateCreateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool HasNewsletterSubscribed { get; set; }
        public byte MembershipTypeId { get; set; }
        public DateTime? Birthdate { get; set; }
        public byte RoleTypeId { get; set; } = 1; //defaultowo user
    }
}
