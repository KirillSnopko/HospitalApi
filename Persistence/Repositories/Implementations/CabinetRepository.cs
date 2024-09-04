using Domain.DbEntities;
using Persistence.Context;
using Persistence.Repositories.Base;
using Persistence.Repositories.Interfaces;


namespace Persistence.Repositories.Implementations;

public sealed class CabinetRepository : AbstractCrudRepository<Cabinet, long>, ICabinetRepository
{
    public CabinetRepository(HospitalContext context) : base(context)
    {
    }
}
