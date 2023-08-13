using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using PlantData.API.Data;
using PlantData.API.Models.Domian;
using PlantData.API.Models.DTO;

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
            // Get Data from DB (Domain models)
            var familiesDomain = plantDataDbContext.Families.ToList();

            // Map Domain Models to Dto
            var familiesDto = new List<FamilyDto>();
            foreach (var family in familiesDomain)
            {
                familiesDto.Add(new FamilyDto
                {
                    Id = family.Id,
                    Name = family.Name,
                    Genus = family.Genus,
                });

            }

            // Return DTOs to client
            return Ok(familiesDto);
        }



        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            // Get Family by ID
            var familyDomain = plantDataDbContext.Families.Find(id);

            if(familyDomain is null)
            {
                return NotFound();
            }

            // Map Domain model to DTO
            var familyDto = new FamilyDto
            {
                Id = familyDomain.Id,
                Name = familyDomain.Name,
                Genus = familyDomain.Genus
            };

            // Return DTO to client
            return Ok(familyDto);
        }


        [HttpPost]
        public IActionResult Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            // Map Dto request to Domain Model
            var familyDomain = new Family
            {
                Name = addRegionRequestDto.Name,
                Genus = addRegionRequestDto.Genus
            };

            // Create table with domain model
            plantDataDbContext.Families.Add(familyDomain);
            plantDataDbContext.SaveChanges();


            return CreatedAtAction(nameof(GetById), new { Id = familyDomain.Id }, familyDomain );
        }
    }
}
