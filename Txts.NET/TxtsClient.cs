using System.Net;
using System.Net.Http.Headers;
using HtmlAgilityPack;
using Txts.NET.Entities;
using Txts.NET.Exceptions;

namespace Txts.NET;

/// <summary>
/// Base txts client
/// </summary>
public class TxtsClient : IDisposable
{
    /// <summary>
    /// Singleton HTTP client
    /// </summary>
    private readonly HttpClient httpClient = new HttpClient();

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="host">Service hostname</param>
    public TxtsClient(string host = "https://txts.sudokoko.xyz")
    {
        this.httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("TxtsAPI", "1.0"));
        this.httpClient.BaseAddress = new Uri(host);
    }

    /// <summary>
    /// Gets a txt by username
    /// </summary>
    /// <param name="username">The username</param>
    /// <returns>The user's txt</returns>
    /// <exception cref="TxtNotFoundException">In case the txt does not exist</exception>
    /// <exception cref="TxtUnexpectedException">In case an unknown error has been returned by the server</exception>
    public async Task<Txt> GetTxtAsync(string username)
    {
        HttpResponseMessage responseMessage = await this.httpClient.GetAsync($"/@{username}");
        if (responseMessage.StatusCode == HttpStatusCode.NotFound)
        {
            throw new TxtNotFoundException("Txt was not found by the server — Error 404");
        }
        if (responseMessage.StatusCode != HttpStatusCode.OK)
        {
            throw new TxtUnexpectedException("Txts service did not reply with OK; error code: ",
                                             responseMessage.StatusCode);
        }

        string html = await responseMessage.Content.ReadAsStringAsync();
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(html);

        HtmlNode primaryContent = doc.DocumentNode.SelectSingleNode("/html/body/main/div");
        HtmlNode header = primaryContent.SelectSingleNode("header");

        // Verified txts will have a <span> tag in the header that contains a class attribute with verified-icon
        bool verified = header.ChildNodes.Any(x => x.Name == "span" && x.Attributes.Contains("class") &&
                                                   x.Attributes["class"].Value == "verified-icon");

        string body = "";
        // Skip the header and the footer (the edit key)
        for (int i = 2; i < primaryContent.ChildNodes.Count - 2; i++)
        {
            if (primaryContent.ChildNodes[i].NodeType == HtmlNodeType.Text) continue;
            body += primaryContent.ChildNodes[i].OuterHtml;
        }

        return new Txt(verified, body);
    }

    /// <summary>
    /// IDisposable's dispose
    /// </summary>
    public void Dispose()
    {
        this.httpClient.Dispose();
        GC.SuppressFinalize(this);
    }
}