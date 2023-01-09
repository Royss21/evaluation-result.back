namespace Application.Dto.Security.Role
{
    using System.Text.Json.Serialization;
    public class RoleDto : BaseRoleDto
    {
        public int Id { get; set; }

        [JsonIgnore]
        public DateTime CreateDate { get; set; }
    }
}
