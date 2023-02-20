namespace Application.Dto.Employee.Collaborator
{
    public abstract class BaseCollaboratorDto
    {
        public int ChargeId { get; set; }
        public string DocumentNumber { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public DateTime? DateBirthday { get; set; }
        public DateTime DateAdmission { get; set; }
        public DateTime? DateEgress { get; set; }
        public int IdentityDocumentId { get; set; }
    }
}
