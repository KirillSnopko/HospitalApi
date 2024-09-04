using JetBrains.Annotations;

namespace Shared;

[UsedImplicitly]
public class ApplicationConfiguration
{
    public string DbConnectionString { get; init; }
}
