# Mhlabs.WebApi.JsendActionFilter
Action filter for optionally wrapping a response in JSend format. See https://labs.omniti.com/labs/jsend.

```csharp
services.AddMvc(s =>
{
    s.AddJSendResponseFormat();
});
```

Example usage:

```csharp
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
