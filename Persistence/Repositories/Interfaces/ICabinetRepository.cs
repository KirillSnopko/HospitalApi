using Domain.DbEntities;
using Persistence.Repositories.Base;

namespace Persistence.Repositories.Interfaces;

public interface ICabinetRepository : ICrudRepository<Cabinet, long> { }
