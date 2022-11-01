﻿namespace Infrastructure.Main.Context.Configuration.EvaResult
{
    using Domain.Main.EvaResult;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EvaluationConfig : BaseEntityTypeConfig<Evaluation, Guid>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Evaluation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.StartDate)
                .IsRequired();

            builder.Property(p => p.EndDate)
                .IsRequired();

            builder.Property(p => p.Weight)
                .IsRequired()
                .HasDefaultValue(0);

            builder.HasMany(c => c.EvaluationCollaborators)
                .WithOne(e => e.Evaluation);

            builder.HasMany(c => c.EvaluationComponents)
                .WithOne(e => e.Evaluation);

            builder.HasMany(c => c.EvaluationLeaders)
                .WithOne(e => e.Evaluation);

            builder.HasMany(c => c.EvaluationStages)
                .WithOne(e => e.Evaluation);

            builder.HasOne(c => c.Period)
                .WithMany(e => e.Evaluations);
        }
    }
}
