using Txts.NET.Entities;
using Txts.NET.Exceptions;

namespace Txts.NET.Tests;

public class ReadTests
{
    private readonly TxtsClient client = new TxtsClient();

    [Test]
    public async Task ValidTxt()
    {
        await this.client.GetTxtAsync("Animadoria");
        Assert.Pass();
    }

    [Test]
    public async Task VerifiedTxt()
    {
        Txt txt = await this.client.GetTxtAsync("Animadoria");
        Assert.That(txt.Verified, Is.True);
    }

    [Test]
    public async Task InvalidTxt()
    {
        try
        {
            // If someone makes a txt with this i'll be pissed
            await this.client.GetTxtAsync("BADBADBAD!!!!!!!!!!");
            Assert.Fail();
        }
        catch (TxtNotFoundException)
        {
            Assert.Pass();
        }
    }
}