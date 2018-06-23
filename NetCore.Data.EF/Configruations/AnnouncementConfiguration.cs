using NetCore.Data.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NetCore.Data.EF.Extensions;

namespace NetCore.Data.EF.Configruations
{
    class AnnouncementConfiguration : DbEntityConfiguration<Announcement>
    {
        public override void Configure(EntityTypeBuilder<Announcement> entity)
        {
            entity.Property(p => p.Id).HasMaxLength(128)
                .IsRequired().IsUnicode(false).HasMaxLength(128);
        }
    }
}
