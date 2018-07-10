using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCore.Data.EF.Extensions;
using NetCore.Data.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Data.EF.Configruations
{
    class ProductTagConfiguration : DbEntityConfiguration<ProductTag>
    {
        public override void Configure(EntityTypeBuilder<ProductTag> entity)
        {
            entity.Property(p => p.TagId).HasMaxLength(50)
                .IsRequired().IsUnicode(false).HasMaxLength(50);
        }
    }
}
