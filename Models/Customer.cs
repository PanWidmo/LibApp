using System;
using System.ComponentModel.DataAnnotations;

namespace LibApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool HasNewsletterSubscribed { get; set; } = false;
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; } = 1;
        public DateTime? Birthdate { get; set; }
        public RoleType RoleType { get; set; }
        public byte RoleTypeId { get; set; } = 1; //defaultowo kazdy bedzie userem

    }
}
