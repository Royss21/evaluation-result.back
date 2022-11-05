﻿namespace Infrastructure.Main.Context.Configuration.EvaResult
{
    using Domain.Main.EvaResult;


    public class ComponentCollaboratorCommentConfig : BaseEntityTypeConfig<ComponentCollaboratorComment, Guid>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ComponentCollaboratorComment> builder)
        {
            builder.ToTable(typeof(ComponentCollaboratorComment).Name, schema: "EvaResult");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Comment)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasOne(b => b.EvaluationCollaborator)
               .WithMany(b => b.ComponentCollaboratorComments);

            builder.HasOne(b => b.EvaluationComponentStage)
              .WithMany(b => b.ComponentCollaboratorStages);

        }
    }
}