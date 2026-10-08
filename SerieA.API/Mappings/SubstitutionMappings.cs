using AutoMapper;
using SerieA.API.DTOs.SubstitutionDtos;
using SerieA.API.Entities;

namespace SerieA.API.Mappings
{
    public class SubstitutionMappings : Profile
    {
        public SubstitutionMappings()
        {
            CreateMap<CreateSubstitutionDto, Substitution>();
            CreateMap<UpdateSubstitutionDto, Substitution>();
            CreateMap<Substitution, ResultSubstitutionDto>();
        }
    }
}
