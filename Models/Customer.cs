﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool HasNewsletterSubscribed { get;set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
        public DateTime? Birthdate { get; set; }
        public RoleType RoleType { get; set; }
        public byte RoleTypeId { get; set; }

    }
}
