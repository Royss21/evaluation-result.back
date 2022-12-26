namespace Application.Main.AutoMapper.Employee
{
    using Application.Dto.Employee.Hierarchy;
    using Domain.Main.Employee;

    public class HierarchyProfile : Profile
    {
        public HierarchyProfile()
        {
            CreateMap<HierarchyDto, Hierarchy>().ReverseMap();
            CreateMap<HierarchyCreateDto, Hierarchy>().ReverseMap();
            CreateMap<HierarchyUpdateDto, Hierarchy>().ReverseMap();
        }
    }
}
