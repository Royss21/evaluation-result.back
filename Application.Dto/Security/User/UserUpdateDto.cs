﻿namespace Application.Dto.Security.User
{
    public class UserUpdateDto : BaseUserDto
    {
        public Guid Id { get; set; }
        public List<int> RolesId { get; set; }
    }
}
