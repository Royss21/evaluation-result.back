﻿namespace Domain.Main.Security
{

    public class UserRole : BaseModel<int>
    {
        public Guid UserId { get; set; }
        public int RoleId { get; set; }

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }

    }
}
