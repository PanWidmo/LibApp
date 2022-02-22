using System;

namespace LibApp.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool HasNewsletterSubscribed { get; set; }
        public MembershipTypeDto MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
        public DateTime? Birthdate { get; set; }
        public RoleTypeDto RoleType { get; set; }
        public byte RoleTypeId { get; set; }
    }
}
