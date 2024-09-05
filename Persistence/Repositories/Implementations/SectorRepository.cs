using Domain.DbEntities;
using Persistence.Context;
using Persistence.Repositories.Base;
using Persistence.Repositories.Interfaces;


namespace Persistence.Repositories.Implementations;

public sealed class SectorRepository : AbstractCrudRepository<Sector, long>, ISectorRepository
{
    public SectorRepository(HospitalContext context) : base(context)
    {
    }
}
