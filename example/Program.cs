var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => Results.Content(HtmlPage(error: null, result: null), "text/html; charset=utf-8"));

app.MapPost("/", async (HttpRequest request) =>
{
    var form = await request.ReadFormAsync();
    var aText = form["a"].ToString();
    var bText = form["b"].ToString();
    var op = form["op"].ToString().Trim();

    if (!double.TryParse(aText, out var a) || !double.TryParse(bText, out var b))
        return Results.Content(HtmlPage("Please enter valid numbers in the first two boxes.", null), "text/html; charset=utf-8");

    if (op.Length == 0)
        return Results.Content(HtmlPage("Please enter +, -, *, or / in the third box.", null), "text/html; charset=utf-8");

    double? value = op switch
    {
        "+" => a + b,
        "-" => a - b,
        "*" => a * b,
        "/" when b == 0 => null,
        "/" => a / b,
        _ => null
    };

    if (op == "/" && b == 0)
        return Results.Content(HtmlPage("Cannot divide by zero.", null), "text/html; charset=utf-8");

    if (value is null)
        return Results.Content(HtmlPage("Third box must be exactly: +  -  *  or  /", null), "text/html; charset=utf-8");

    var line = $"{a} {op} {b} = {value}";
    return Results.Content(HtmlPage(null, line), "text/html; charset=utf-8");
});

app.Run();

static string HtmlPage(string? error, string? result)
{
    var err = error is null
        ? ""
        : $"<p class=\"err\">{System.Net.WebUtility.HtmlEncode(error)}</p>";
    var ok = result is null
        ? ""
        : $"<p class=\"ok\">{System.Net.WebUtility.HtmlEncode(result)}</p>";

    return $@"<!DOCTYPE html>
<html lang=""en"">
<head>
<meta charset=""utf-8"">
<meta name=""viewport"" content=""width=device-width, initial-scale=1"">
<title>Simple calculator</title>
<style>
body {{ font-family: Segoe UI, system-ui, sans-serif; max-width: 22rem; margin: 2rem auto; padding: 0 1rem; }}
h1 {{ font-size: 1.25rem; }}
label {{ display: block; margin-top: 0.75rem; }}
input {{ width: 100%; box-sizing: border-box; padding: 0.4rem; }}
button {{ margin-top: 1rem; padding: 0.45rem 1rem; }}
.err {{ color: #b00020; }}
.ok {{ color: #0a0; font-weight: 600; }}
</style>
</head>
<body>
<h1>Calculator (3 inputs)</h1>
<form method=""post"" action=""/"">
  <label>First number<br><input name=""a"" type=""number"" step=""any"" required></label>
  <label>Second number<br><input name=""b"" type=""number"" step=""any"" required></label>
  <label>Operation<br><input name=""op"" type=""text"" maxlength=""1"" required placeholder=""+""></label>
  <button type=""submit"">Calculate</button>
</form>
{err}
{ok}
</body>
</html>";
}
