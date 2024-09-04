using Domain.DbEntities;
using Persistence.Context;
using Persistence.Repositories.Base;
using Persistence.Repositories.Interfaces;

namespace Persistence.Repositories.Implementations;

public sealed class DoctorRepository : AbstractCrudRepository<Doctor, long>, IDoctorRepository
{
    public DoctorRepository(HospitalContext context) : base(context)
    {
    }
}
