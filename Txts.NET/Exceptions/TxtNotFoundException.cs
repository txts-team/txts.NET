namespace Txts.NET.Exceptions;

/// <summary>
/// Exception if txt does not exist
/// </summary>
public class TxtNotFoundException : TxtException
{
    public TxtNotFoundException(string? message) : base(message)
    {
    }
}