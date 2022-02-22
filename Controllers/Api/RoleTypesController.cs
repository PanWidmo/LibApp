using LibApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleTypesController : Controller
    {
        private readonly IRoleTypeService roleTypeService;

        public RoleTypesController(IRoleTypeService roleTypeService)
        {
            this.roleTypeService = roleTypeService;
        }

        // GET /api/roletypes
        public IActionResult GetAllRoleTypes()
        {
            var result = roleTypeService.GetAllRoleTypes();

            return Ok(result);
        }
    }
}
