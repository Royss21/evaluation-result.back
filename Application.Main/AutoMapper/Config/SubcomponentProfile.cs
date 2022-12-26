namespace Application.Main.AutoMapper.Employee
{
    using Application.Dto.Config.Subcomponent;
    using Application.Dto.Config.SubcomponentValue;
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

            CreateMap<Subcomponent, SubcomponentDataConfigurationDto>()
                .ForMember(x => x.Id, m => m.MapFrom(d => d.Id))
                .ForMember(x => x.Name, m => m.MapFrom(d => d.Name))
                .ForMember(x => x.ComponentId, m => m.MapFrom(d => d.ComponentId))
                .ForMember(x => x.AreaName, m => m.MapFrom(d => d.Area.Name))
                .ForMember(x => x.FormulaId, m => m.MapFrom(d => d.FormulaId))
                .ForMember(x => x.FormulaName, m => m.MapFrom(d => d.Formula.Name))
                .ForMember(x => x.FormulaQuery, m => m.MapFrom(d => d.Formula.FormulaQuery))
                .ForMember(x => x.SubcomponentValues, m => m.MapFrom(d => d.SubcomponentValues.Select(s => new SubcomponentValueDataConfigurationDto { 
                    SubcomponentId = s.SubcomponentId,
                    ChargeName = s.Charge.Name,
                    RelativeWeight =s.RelativeWeight,
                    MinimunPercentage = s.MinimunPercentage,
                    MaximunPercentage = s.MaximunPercentage,
                })))
                .ReverseMap();
        }
    }
}
