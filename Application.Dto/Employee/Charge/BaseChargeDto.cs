namespace Application.Dto.Employee.Charge
{
    public abstract class BaseChargeDto
    {
        public string Name { get; set; } = string.Empty;
        public int AreaId { get; set; }
        public int HierarchyId { get; set; }
    }
}
