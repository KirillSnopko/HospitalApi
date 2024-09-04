using Domain.DbEntities;
using Persistence.Repositories.Base;


namespace Persistence.Repositories.Interfaces;

public interface ISectorRepository : ICrudRepository<Sector, long> { }
