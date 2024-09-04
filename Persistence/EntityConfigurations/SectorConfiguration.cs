using Domain.DbEntities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Schemas;


namespace Persistence.EntityConfigurations;

[UsedImplicitly]
internal class SectorConfiguration : BaseEntityConfiguration<Sector, long>
{
    public override void Configure(EntityTypeBuilder<Sector> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Number).HasColumnName(SectorSchema.Columns.Number);

        builder.ToTable(SectorSchema.Table);
    }
}
