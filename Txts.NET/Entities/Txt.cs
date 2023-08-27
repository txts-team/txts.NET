namespace Txts.NET.Entities;

/// <summary>
/// Someone's txt
/// </summary>
public readonly struct Txt
{
    /// <summary>
    /// Was the txt verified by the site administrators?
    /// </summary>
    public bool Verified { get; }

    /// <summary>
    /// Body of the txt in HTML format
    /// </summary>
    public string Body { get; }

    /// <summary>
    /// Internal constructor
    /// </summary>
    /// <param name="verified">If verified</param>
    /// <param name="body">HTML body</param>
    internal Txt(bool verified, string body)
    {
        this.Verified = verified;
        this.Body = body;
    }

    /// <summary>
    /// ToString formaatter
    /// </summary>
    /// <returns>String representation of this txt</returns>
    public override string ToString()
    {
        return $"{nameof(this.Verified)}: {this.Verified}\n{nameof(this.Body)}: {this.Body}";
    }
}