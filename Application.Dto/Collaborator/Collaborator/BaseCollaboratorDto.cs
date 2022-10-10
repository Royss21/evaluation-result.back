namespace Application.Dto.Employee.Employee
{
    public abstract class BaseCollaboratorDto
    {
        public int IdCharge { get; set; }
        public string DocumentNumber { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string DateBirthday { get; set; } = string.Empty;
        public string DateAdmission { get; set; } = string.Empty;
        public string DateEgress { get; set; } = string.Empty;
    }
}
