using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using PlantData.API.Data;
using PlantData.API.Models.Domian;

namespace PlantData.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyController : ControllerBase
    {
        private readonly PlantDataDbContext plantDataDbContext;

        public FamilyController(PlantDataDbContext plantDataDbContext)
        {
            this.plantDataDbContext = plantDataDbContext;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var families = plantDataDbContext.Families.ToList();
            return Ok(families);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {

        }
    }
}
