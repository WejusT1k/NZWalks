using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }
        // CREATE WALK
        // POST: /api/walks
        [HttpPost]

        public async Task<IActionResult> Create([FromBody] AddWalkRequestDTO addWalkRequestDTO)
        {
            if(ModelState.IsValid) 
            {
                var walkDomainModel = mapper.Map<Walk>(addWalkRequestDTO);
                await walkRepository.CreateAsync(walkDomainModel);

                return Ok(mapper.Map<WalkDTO>(walkDomainModel));
            }
            else
            {
                return BadRequest(ModelState);
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            
            var walksDomainModel = await walkRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);

            return Ok(mapper.Map<List<WalkDTO>>(walksDomainModel));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.GetByIdAsync(id);
            if (walkDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDTO>(walkDomainModel));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDTO updateWalkRequestDTO)
        {
            if (ModelState.IsValid)
            {
                var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDTO);
                walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);
                if (walkDomainModel == null)
                {
                    return NotFound();
                }
                return Ok(mapper.Map<WalkDTO>(walkDomainModel));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Delete(Guid id)
        {
            var walkDomainModel = await walkRepository.DeleteAsync(id);
            if(walkDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDTO>(walkDomainModel));

        }
    }
}
