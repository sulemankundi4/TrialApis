using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
      public async Task<IActionResult> AddWalk([FromBody] AddWalkRequestDto addWalkRequestDto)
      {
         var walkDomainModel = _mapper.Map<Walk>(addWalkRequestDto);
         await _walkRepository.AddWalkAsync(walkDomainModel);

         return Ok(_mapper.Map<WalkDto>(walkDomainModel));
      }

   }
}