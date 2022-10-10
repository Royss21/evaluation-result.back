namespace Domain.Main.Employee
{
    public class Collaborator : BaseModel<string>
    {
        public int IdCharge { get; set; }
        public string DocumentNumber { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public DateTime DateBirthday { get; set; } 
        public DateTime DateAdmission { get; set; } 
        public DateTime DateEgress { get; set; }

        public Charge Charge { get; set; }
    }
}
