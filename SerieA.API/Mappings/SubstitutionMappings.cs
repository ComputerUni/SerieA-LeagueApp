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
            CreateMap<Substitution, ResultSubstitutionDto>()
                .ForMember(dest => dest.PlayerInName, opt => opt.MapFrom(src => $"{src.PlayerIn.FirstName} {src.PlayerIn.LastName}"))
                .ForMember(dest => dest.PlayerOutName, opt => opt.MapFrom(src => $"{src.PlayerOut.FirstName} {src.PlayerOut.LastName}"));
        }
    }
}
