using AutoMapper;
using Domain.DataTransferObjects;
using Domain.DbEntities;

namespace Persistence.Mapping;

public sealed class PatientMapping : Profile
{
    public PatientMapping()
    {
        CreateMap<Patient, PatientDto>()
            .ForMember(x => x.Id, u => u.MapFrom(x => x.Id))
            .ForMember(x => x.FirstName, u => u.MapFrom(x => x.FirstName))
            .ForMember(x => x.LastName, u => u.MapFrom(x => x.LastName))
            .ForMember(x => x.Patronymic, u => u.MapFrom(x => x.Patronymic))
            .ForMember(x => x.Address, u => u.MapFrom(x => x.Address))
            .ForMember(x => x.DateOfBirth, u => u.MapFrom(x => x.DateOfBirth))
            .ForMember(x => x.Gender, u => u.MapFrom(x => x.Gender))
            .ForMember(x => x.SectorNumber, u => u.MapFrom(x => x.Sector.Number));

        CreateMap<Patient, PatientEditDto>()
            .ForMember(x => x.Id, u => u.MapFrom(x => x.Id))
            .ForMember(x => x.FirstName, u => u.MapFrom(x => x.FirstName))
            .ForMember(x => x.LastName, u => u.MapFrom(x => x.LastName))
            .ForMember(x => x.Patronymic, u => u.MapFrom(x => x.Patronymic))
            .ForMember(x => x.Address, u => u.MapFrom(x => x.Address))
            .ForMember(x => x.DateOfBirth, u => u.MapFrom(x => x.DateOfBirth))
            .ForMember(x => x.Gender, u => u.MapFrom(x => x.Gender))
            .ForMember(x => x.SectorId, u => u.MapFrom(x => x.SectorId));
    }
}
