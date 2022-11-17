namespace Application.Main.AutoMapper.Employee
{
    using Application.Dto.Config.Formula;
    using Domain.Main.Config;

    public class FormulaProfile : Profile
    {
        public FormulaProfile()
        {
            CreateMap<FormulaCreateDto, Formula>().ReverseMap();
            CreateMap<FormulaDto, Formula>().ReverseMap();
            CreateMap<FormulaUpdateDto, Formula>().ReverseMap();
        }
    }
}
