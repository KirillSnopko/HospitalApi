using Domain.DbEntities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Schemas;

namespace Persistence.EntityConfigurations;

[UsedImplicitly]
internal class DoctorConfiguration : BaseEntityConfiguration<Doctor, long>
{
    public override void Configure(EntityTypeBuilder<Doctor> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.FIO).HasColumnName(DoctorSchema.Columns.FIO);

        builder.Property(x => x.CabinetId).HasColumnName(DoctorSchema.Columns.CabinetId);

        builder.Property(x => x.SpecializationId).HasColumnName(DoctorSchema.Columns.SpecializationId);

        builder.Property(x => x.SectorId).HasColumnName(DoctorSchema.Columns.SectorId);

        builder.HasIndex(x => x.FIO).HasFilter($"{ColumnsBase.IsDeleted} = false").IsUnique();

        builder.ToTable(DoctorSchema.Table);
    }
}
