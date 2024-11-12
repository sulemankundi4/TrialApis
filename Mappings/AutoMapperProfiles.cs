using AutoMapper;
using TrialApis.Models.Domains;
using TrialApis.Models.DTOs;

namespace TrialApis.Mappings
{
   public class AutoMapperProfiles : Profile
   {
      public AutoMapperProfiles()
      {
         CreateMap<Region, RegionDto>().ReverseMap();
         CreateMap<AddRegionRequestDto, Region>().ReverseMap();
         CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();
         CreateMap<Walk, AddWalkRequestDto>().ReverseMap();
         CreateMap<Walk, WalkDto>().ReverseMap();
      }
   }
}