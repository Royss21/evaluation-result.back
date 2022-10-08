namespace Domain.Main.Collaborator
{
    public class Collaborator : BaseModel<int>
    {
        public int IdCharge { get; set; }
        //TODO: Falta relacionar esta tabla con la Tabla DocumentType
        public int DocumentType { get; set; }
        public string DocumentNumber { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string DateBirthday { get; set; } = string.Empty;
        public string DateAdmission { get; set; } = string.Empty;
        public string DateEgress { get; set; } = string.Empty;


        public Charge? Charge { get; set; }
    }
}
