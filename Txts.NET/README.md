# txts.NET
## Core Library

This is the core library.

`TxtsClient` is what you need to use. IntelliSense is your friend.

#### Example:

```csharp
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
```