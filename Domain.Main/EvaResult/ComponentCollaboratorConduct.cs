﻿namespace Domain.Main.EvaResult
{
    public class ComponentCollaboratorConduct : BaseModel<int>
    {
        public string IdComponentCollaboratorDetail { get; set; } = string.Empty;
        public string LevelName { get; set; } = string.Empty;
        public int Points { get; set; }

        public ComponentCollaboratorDetail ComponentCollaboratorDetail { get; set; }
    }
}