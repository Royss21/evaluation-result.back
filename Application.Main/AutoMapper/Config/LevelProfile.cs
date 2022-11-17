namespace Application.Main.AutoMapper.Employee
{
    using Application.Dto.Config.Level;
    using Domain.Main.Config;

    public class LevelProfile : Profile
    {
        public LevelProfile()
        {
            CreateMap<Level, LevelDependencyDto>()
                .ForMember(x => x.HasDependencyConduct, m => m.MapFrom(d => d.Conducts.Any()))
                .ForMember(x => x.HasDependencyHierarchy, m => m.MapFrom(d => d.Hierarchies.Any()))
                .ReverseMap();

            CreateMap<LevelCreateDto, Level>().ReverseMap();
            CreateMap<LevelDto, Level>().ReverseMap();
            CreateMap<LevelUpdateDto, Level>().ReverseMap();
        }
    }
}
