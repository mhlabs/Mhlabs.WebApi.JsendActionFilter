# Mhlabs.WebApi.JsendActionFilter
Action filter for optionally wrapping a response in Jsend format

```
services.AddMvc(s =>
{
    s.Filters.Add(new ResponseFilterAttribute());
    s.Filters.Add(new HandleExcpetionFilterAttribute());
});
```
