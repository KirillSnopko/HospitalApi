using Domain.DbEntities;
using Persistence.Repositories.Interfaces;

namespace Persistence.DbInitializer;

public sealed class DatabaseInitializer : IDatabaseInitializer
{
    private readonly ICabinetRepository _cabinetRepository;
    private readonly ISpecializationRepository _specializationRepository;
    private readonly ISectorRepository _sectorRepository;
    private readonly IDoctorRepository _doctorRepository;

    private readonly int[] Cabinets = new[] { 100, 101, 102, 103, 104, 105, 200, 201, 202, 203, 204, 205 };
    private readonly string[] Specializations = new[] { "Кардиолог", "Терапевт", "Хирург", "Oфтальмолог", "Психиатр" };
    private readonly int[] Sectors = new[] { 554, 265, 354, 469 };
    private readonly string[] Doctors = new[] { "A.A. Иванов", "И.И. Петров" };

    public DatabaseInitializer(ICabinetRepository cabinetRepository, ISpecializationRepository specializationRepository, ISectorRepository sectorRepository, IDoctorRepository doctorRepository)
    {
        _cabinetRepository = cabinetRepository;
        _specializationRepository = specializationRepository;
        _sectorRepository = sectorRepository;
        _doctorRepository = doctorRepository;
    }

    public async Task InitializeIfNeededAsync()
    {
        await InitCabinets();
        await InitSpicialization();
        await InitSectors();
        await InitDoctors();
    }

    private async Task InitCabinets()
    {
        if (!_cabinetRepository.Queryable().Any())
        {
            var cabinets = Cabinets.Select(x => new Cabinet { Number = x }).ToList();
            await _cabinetRepository.CreateAsync(cabinets);
        }
    }

    private async Task InitSpicialization()
    {
        if (!_specializationRepository.Queryable().Any())
        {
            var specializations = Specializations.Select(x => new Specialization { Name = x }).ToList();
            await _specializationRepository.CreateAsync(specializations);
        }
    }

    private async Task InitSectors()
    {
        if (!_sectorRepository.Queryable().Any())
        {
            var sectors = Sectors.Select(x => new Sector { Number = x }).ToList();
            await _sectorRepository.CreateAsync(sectors);
        }
    }

    private async Task InitDoctors()
    {
        if (!_doctorRepository.Queryable().Any())
        {
            var id = 1;
            var doctors = Doctors.Select(x => new Doctor { FIO = x, CabinetId = id++, SectorId = id, SpecializationId = id }).ToList();
            await _doctorRepository.CreateAsync(doctors);
        }
    }
}
