using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrialApis.CustomActionFilters;
using TrialApis.Models.Domains;
using TrialApis.Models.DTOs;
using TrialApis.Repositories;

namespace TrialApis.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class WalkController : ControllerBase
   {
      private readonly IMapper _mapper;
      private readonly IWalkRepository _walkRepository;
      public WalkController(IMapper mapper, IWalkRepository walkRepository)
      {
         _mapper = mapper;
         _walkRepository = walkRepository;
      }

      [HttpPost]
      [ValidateModel]
      public async Task<IActionResult> AddWalk([FromBody] AddWalkRequestDto addWalkRequestDto)
      {

         var walkDomainModel = _mapper.Map<Walk>(addWalkRequestDto);
         await _walkRepository.AddWalkAsync(walkDomainModel);

         return Ok(_mapper.Map<WalkDto>(walkDomainModel));
      }

      [HttpGet]
      public async Task<IActionResult> GetWalks()
      {
         var AllWalksDomain = await _walkRepository.GetAllWalksAsync();

         // Mapping domain model to dtos
         return Ok(_mapper.Map<List<WalkDto>>(AllWalksDomain));
      }

      [HttpGet("{id:guid}")]
      public async Task<IActionResult> GetSingleWalk(Guid id)
      {
         var checkWalkExists = await _walkRepository.GetSingleWalkAsync(id);
         if (checkWalkExists == null)
         {
            return NotFound();
         }

         return Ok(_mapper.Map<WalkDto>(checkWalkExists));
      }

      [HttpPut("{id:guid}")]
      [ValidateModel]
      public async Task<IActionResult> UpdateWalkAsync(Guid id, UpdateWalkRequestDto updateWalkRequestDto)
      {

         var walkDomainModel = _mapper.Map<Walk>(updateWalkRequestDto);

         walkDomainModel = await _walkRepository.UpdateWalkByIdAsync(id, walkDomainModel);

         if (walkDomainModel == null)
         {
            return NotFound();
         }

         return Ok(_mapper.Map<WalkDto>(walkDomainModel));


      }

      [HttpDelete("{id:guid}")]
      public async Task<IActionResult> DeleteWalk([FromRoute] Guid id)
      {
         var walkDomainModel = _walkRepository.DeleteWalkAsync(id);
         if (walkDomainModel == null)
         {
            return NotFound();
         }

         return Ok(_mapper.Map<WalkDto>(walkDomainModel));
      }
   }
}