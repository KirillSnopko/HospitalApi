﻿using AutoMapper;
using Domain.DataTransferObjects;
using Domain.DbEntities;
using JetBrains.Annotations;

namespace Persistence.Mapping;

[UsedImplicitly]
public sealed class DoctorMapping : Profile
{
    public DoctorMapping()
    {
        CreateMap<Doctor, DoctorDto>()
             .ForMember(x => x.Id, u => u.MapFrom(x => x.Id))
             .ForMember(x => x.FIO, u => u.MapFrom(x => x.FIO))
             .ForMember(x => x.Specialization, u => u.MapFrom(x => x.Specialization.Name))
             .ForMember(x => x.CabinetNumber, u => u.MapFrom(x => x.Cabinet.Number))
             .ForMember(x => x.SectorNumber, u => u.MapFrom(x => x.Sector.Number));

        CreateMap<Doctor, DoctorEditDto>()
            .ForMember(x => x.Id, u => u.MapFrom(x => x.Id))
            .ForMember(x => x.FIO, u => u.MapFrom(x => x.FIO))
            .ForMember(x => x.SpecializationId, u => u.MapFrom(x => x.SpecializationId))
            .ForMember(x => x.CabinetId, u => u.MapFrom(x => x.CabinetId))
            .ForMember(x => x.SectorId, u => u.MapFrom(x => x.SectorId));
    }
}
