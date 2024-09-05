using Domain.DbEntities;
using Persistence.Context;
using Persistence.Repositories.Base;
using Persistence.Repositories.Interfaces;


namespace Persistence.Repositories.Implementations;

public sealed class SpecializationRepository : AbstractCrudRepository<Specialization, long>, ISpecializationRepository
{
    public SpecializationRepository(HospitalContext context) : base(context) { }
}
