using System.Runtime.Serialization;

namespace Shared.Exceptions;

[Serializable]
public class HospitalNotFoundException : Exception
{
    public HospitalNotFoundException()
    {
    }

    public HospitalNotFoundException(string? message) : base(message)
    {
    }

    public HospitalNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
