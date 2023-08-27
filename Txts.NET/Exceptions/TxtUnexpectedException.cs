using System.Net;

namespace Txts.NET.Exceptions;

/// <summary>
/// Exception for unknown status codes returned by the server
/// </summary>
public class TxtUnexpectedException : TxtException
{
    /// <summary>
    /// HTTP Status code returned by the server
    /// </summary>
    public HttpStatusCode Code { get; }

    public TxtUnexpectedException(string? message, HttpStatusCode code) : base(message)
    {
        this.Code = code;
    }
}