 using NetCore.Data.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using NetCore.Data.EF.Extensions;

namespace NetCore.Data.EF.Configruations
{
    class SystemConfigConfiguration : DbEntityConfiguration<Config>
    {
        public override void Configure(EntityTypeBuilder<Config> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(255).IsRequired();
            // etc.
        }
    }
}
