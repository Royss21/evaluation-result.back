﻿

namespace Infrastructure.Main.Context.Configuration.Admin
{
    
    using Infrastructure.Main.Context.Base;
    public class MenuConfig : BaseEntityTypeConfig<Menu, Guid>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Menu> builder)
        {
            //builder.Property(p => p.Name)
            //    .IsRequired()
            //    .HasMaxLength(100);

            //builder.Property(p => p.Url)
            //    .IsRequired()
            //    .HasMaxLength(300);

            //builder.Property(p => p.Icon)
            //    .HasMaxLength(50);
        }
    }
}
