using Txts.NET;
using Txts.NET.Entities;
using Txts.NET.Exceptions;

// Zoo: random test place.

Console.WriteLine("Enter username:");
string? target = Console.ReadLine();

if (target == null)
{
    Console.WriteLine("Username was null, stopping.");
    return;
}

using TxtsClient client = new TxtsClient();
try
{
    Txt txt = await client.GetTxtAsync(target);
    Console.WriteLine(txt);
}
catch (TxtNotFoundException)
{
    Console.WriteLine("Txt was not found!");
}
catch (TxtUnexpectedException e)
{
    Console.WriteLine("Unexpected error code: " + e.Code);
}