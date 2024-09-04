using Domain.DbEntities;
using Persistence.Repositories.Interfaces;

namespace Persistence.DbInitializer;

public sealed class DatabaseInitializer : IDatabaseInitializer
{
    private readonly ICabinetRepository _cabinetRepository;
    private readonly ISpecializationRepository _specializationRepository;
    private readonly ISectorRepository _sectorRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IPatientRepository _petientRepository;
    public async Task InitializeIfNeededAsync()
    {
        await InitCabinets();
        await InitSpicialization();
        await InitSectors();
    }

    private async Task InitCabinets()
    {
        if (!_cabinetRepository.Queryable().Any())
        {
            var data = new[] { 100, 101, 102, 103, 104, 105, 200, 201, 202, 203, 204, 205 };
            var cabinets = data.Select(x => new Cabinet { Number = x }).ToList();
            await _cabinetRepository.CreateAsync(cabinets);
        }
    }

    private async Task InitSpicialization()
    {
        if (!_specializationRepository.Queryable().Any())
        {
            var data = new[] { "Кардиолог", "Терапевт", "Хирург", "Oфтальмолог", "Психиатр" };
            var specializations = data.Select(x => new Specialization { Name = x }).ToList();
            await _specializationRepository.CreateAsync(specializations);
        }
    }

    private async Task InitSectors()
    {
        if (!_sectorRepository.Queryable().Any())
        {
            var data = new[] { 554, 265, 354, 469 };
            var sectors = data.Select(x => new Sector { Number = x }).ToList();
            await _sectorRepository.CreateAsync(sectors);
        }
    }
}
