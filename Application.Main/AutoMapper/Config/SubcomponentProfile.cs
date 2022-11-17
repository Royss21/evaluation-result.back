namespace Application.Main.AutoMapper.Employee
{
    using Application.Dto.Config.Subcomponent;
    using Domain.Main.Config;

    public class SubcomponentProfile : Profile
    {
        public SubcomponentProfile()
        {
            CreateMap<Subcomponent, SubcomponentDto>()
                .ForMember(x => x.AreaName, m => m.MapFrom(d => d.Area.Name))
                .ForMember(x => x.FormulaName, m => m.MapFrom(d => d.Formula.Name))
                .ForMember(x => x.ChargeCount, m => m.MapFrom(d => d.Area.Charges.Where(w => !w.IsDeleted).Count()))
                .ForMember(x => x.ChargeCountAssigned, m => m.MapFrom(d => d.SubcomponentValues.Where(w => !w.IsDeleted).Count()))
                .ReverseMap();

            CreateMap<SubcomponentCreateDto, Subcomponent>().ReverseMap();
            CreateMap<SubcomponentUpdateDto, Subcomponent>().ReverseMap();
        }
    }
}
