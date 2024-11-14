using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrialApis.CustomActionFilters;
using TrialApis.Data;
using TrialApis.Models.Domains;
using TrialApis.Models.DTOs;
using TrialApis.Repositories;

namespace TrialApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _dbContext;
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;
        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            _dbContext = dbContext;
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get Data from the database -- Domain Model
            var regionsDomain = await _regionRepository.GetAllAsync();

            // Return Dto
            return Ok(_mapper.Map<List<RegionDto>>(regionsDomain));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetRegionById([FromRoute] Guid id)
        {
            var regionById = await _regionRepository.GetRegionByIdAsync(id);

            if (regionById == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RegionDto>(regionById));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateRegion([FromBody] AddRegionRequestDto requestRegionData)
        {
            var regionDomainModel = _mapper.Map<Region>(requestRegionData);
            regionDomainModel = await _regionRepository.CreateAsync(regionDomainModel);

            // Map data back to the dto
            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);

            return CreatedAtAction(nameof(GetRegionById), new { Id = regionDto.Id }, regionDto);

        }

        [HttpPut("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {

            var regionDomainModel = _mapper.Map<Region>(updateRegionRequestDto);
            regionDomainModel = await _regionRepository.UpdateRegionAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RegionDto>(regionDomainModel));

        }

        [HttpDelete("{id:guid}")]

        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            var regionDomainModel = await _regionRepository.DeleteRegionAsync(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RegionDto>(regionDomainModel));
        }
    }
}