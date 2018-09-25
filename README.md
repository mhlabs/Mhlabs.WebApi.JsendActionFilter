# Mhlabs.WebApi.JsendActionFilter

Action filter for optionally wrapping a response in JSend format.

See [https://labs.omniti.com/labs/jsend](https://labs.omniti.com/labs/jsend).

_To enable, add the filter as middleware._

```csharp
services.AddMvc(s =>
{
    s.AddJSendResponseFormat();
});
```

_Example usage:_

```csharp
[HttpGet]
public ActionResult<bool> GetIt(string id, CancellationToken cancellationToken)
{
    if (string.IsNullOrWhiteSpace(id))
    {
        return this.Error("NO_ID", "Didn't get it.");
    }

    return true;
}

[HttpGet]
public async Task<DtoObject> Get(string id, CancellationToken cancellationToken)
{
    if (string.IsNullOrEmpty(id))
    {
        this.Fail("INVALID_ID", "Id is invalid");
    }

    var dto = await _handler.GetObject(id, cancellationToken);

    if (dto == null)
    {
        this.Fail("NOT_FOUND");
    }

    return dto;
}
```
