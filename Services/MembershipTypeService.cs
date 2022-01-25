using LibApp.Data;
using LibApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Services
{
    public interface IMembershipTypeService
    {
        public IEnumerable<MembershipType> GetAllMembershipTypes();
    }

    public class MembershipTypeService : IMembershipTypeService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public MembershipTypeService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IEnumerable<MembershipType> GetAllMembershipTypes()
        {
            var membershipTypes = applicationDbContext.MembershipTypes.ToList();

            return membershipTypes;
        }

    }
}
