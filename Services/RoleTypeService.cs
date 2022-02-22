using LibApp.Data;
using LibApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace LibApp.Services
{
    public interface IRoleTypeService
    {
        public IEnumerable<RoleType> GetAllRoleTypes();
    }

    public class RoleTypeService : IRoleTypeService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public RoleTypeService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IEnumerable<RoleType> GetAllRoleTypes()
        {
            var roleTypes = applicationDbContext.RoleTypes.ToList();

            return roleTypes;
        }
    }
}
