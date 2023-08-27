using System.Runtime.Serialization;

namespace Txts.NET.Exceptions;

/// <summary>
/// Base Exception for Txt-specific exceptions
/// </summary>
public abstract class TxtException : Exception
{
    protected TxtException()
    {
    }

    protected TxtException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    protected TxtException(string? message) : base(message)
    {
    }

    protected TxtException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}