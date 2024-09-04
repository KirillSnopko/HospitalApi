using Domain.DbEntities;
using Persistence.Repositories.Base;

namespace Persistence.Repositories.Interfaces;

public interface ISpecializationRepository : ICrudRepository<Specialization, long> { }
