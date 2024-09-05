using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Exceptions;

public class HospitalDuplicateException : Exception
{
    public HospitalDuplicateException()
    {
    }

    public HospitalDuplicateException(string? message) : base(message)
    {
    }

    public HospitalDuplicateException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
