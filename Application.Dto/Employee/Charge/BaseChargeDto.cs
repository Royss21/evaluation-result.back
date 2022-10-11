namespace Application.Dto.Employee.Charge
{
    public abstract class BaseChargeDto
    {
        public string Name { get; set; } = string.Empty;
        public int IdArea { get; set; }
        public int IdHierarchy { get; set; }
    }
}
