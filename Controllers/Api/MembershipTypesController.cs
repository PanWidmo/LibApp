using LibApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipTypesController : Controller
    {
        private readonly IMembershipTypeService membershipTypeService;

        public MembershipTypesController(IMembershipTypeService membershipTypeService)
        {
            this.membershipTypeService = membershipTypeService;
        }

        // GET /api/membershiptypes
        [HttpGet]
        public IActionResult GetAllMembershipTypes()
        {
            var result = membershipTypeService.GetAllMembershipTypes();

            return Ok(result);
        }
    }
}
