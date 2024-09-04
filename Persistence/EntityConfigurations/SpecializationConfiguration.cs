using Domain.DbEntities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Schemas;

namespace Persistence.EntityConfigurations;

[UsedImplicitly]
internal class SpecializationConfiguration : BaseEntityConfiguration<Specialization, long>
{
    public override void Configure(EntityTypeBuilder<Specialization> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Name).HasColumnName(SpecializationSchema.Columns.Name);

        builder.ToTable(SpecializationSchema.Table);
    }
}
