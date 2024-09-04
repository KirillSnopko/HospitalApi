﻿using Domain.DbEntities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Schemas;


namespace Persistence.EntityConfigurations;

[UsedImplicitly]
internal class PatientConfiguration : BaseEntityConfiguration<Patient, long>
{
    public override void Configure(EntityTypeBuilder<Patient> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.FirstName).HasColumnName(PatientSchema.Columns.FirstName);

        builder.Property(x => x.LastName).HasColumnName(PatientSchema.Columns.LastName);

        builder.Property(x => x.Patronymic).HasColumnName(PatientSchema.Columns.Patronymic);

        builder.Property(x => x.Address).HasColumnName(PatientSchema.Columns.Address);

        builder.Property(x => x.DateOfBirth).HasColumnName(PatientSchema.Columns.DateOfBirth);

        builder.Property(x => x.SectorId).HasColumnName(PatientSchema.Columns.SectorId);

        builder.ToTable(PatientSchema.Table);
    }
}
