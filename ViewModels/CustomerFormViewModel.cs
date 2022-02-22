using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LibApp.Models;

namespace LibApp.ViewModels
{
    public class CustomerFormViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Please provide name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please provide email")]
        [StringLength(255)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please provide password")]
        [StringLength(255)]
        [MinLength(5)]
        [Display(Name = "Password")]
        public string PasswordHash { get; set; }

        public bool HasNewsletterSubscribed { get; set; }

        [Required(ErrorMessage ="Please select Membership Type")]
        [Display(Name = "Membership Type")]
        public byte? MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfMember]
        public DateTime? Birthdate { get; set; }

        [Display(Name = "Role Type")]
        public byte? RoleTypeId { get; set; }

        public IEnumerable<RoleType> RoleTypes { get; set; }

        public IEnumerable<MembershipType> MembershipTypes { get; set; }


        public CustomerFormViewModel()
        {
            Id = 0;
        }

        public CustomerFormViewModel(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            Email = customer.Email;
            PasswordHash = customer.PasswordHash;
            MembershipTypeId = customer.MembershipTypeId;
            HasNewsletterSubscribed = customer.HasNewsletterSubscribed;
            Birthdate = customer.Birthdate;
            RoleTypeId = customer.RoleTypeId;

        }
    }
}
