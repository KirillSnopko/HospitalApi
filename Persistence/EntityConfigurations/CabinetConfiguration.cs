using Domain.DbEntities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Persistence.Schemas;

namespace Persistence.EntityConfigurations;

[UsedImplicitly]
internal class CabinetConfiguration : BaseEntityConfiguration<Cabinet, long>
{
    public override void Configure(EntityTypeBuilder<Cabinet> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Number).HasColumnName(CabinetSchema.Columns.Number);

        builder.ToTable(CabinetSchema.Table);
    }
}
