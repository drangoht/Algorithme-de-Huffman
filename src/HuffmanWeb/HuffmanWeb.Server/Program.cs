using HuffmanWeb.Algorithm;
using HuffmanWeb.Algorithm.Extensions;
using HuffmanWeb.Common.DTOs;
using HuffmanWeb.Common.DTOs.Requests;
using HuffmanWeb.Common.DTOs.Responses;
using Serilog;
using Scalar.AspNetCore;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddProblemDetails();

// For production avoid AllowAll
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

var app = builder.Build();
app.UseStatusCodePages(statusCodeHandlerApp =>
{
    statusCodeHandlerApp.Run(async httpContext =>
    {
        var pds = httpContext.RequestServices.GetService<IProblemDetailsService>();
        if (pds == null
            || !await pds.TryWriteAsync(new() { HttpContext = httpContext }))
        {
            await httpContext.Response.WriteAsync("Fallback: An error occurred.");
        }
    });
});
app.UseCors("AllowAll");

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    app.MapGet("/swagger", () => Results.Redirect("/scalar/v1")).ExcludeFromDescription();
}

app.UseHttpsRedirection();

app.MapPost("/huffman/encode", (EncodeRequest req) =>
{
    try
    {
        var nodes = Huffman.GetNodesFromString(req.TextToEncode);
        var graph = Huffman.GenerateHuffmanGraph(nodes);
        graph.ComputeDescendants();
        var huffmanTable = Huffman.MakeMatchingTable(graph);
        var textEncoded = Huffman.EncodeText(req.TextToEncode, huffmanTable);

        var resp = new EncodeResponse
        {
            Graph = graph,
            EncodedBinaryString = textEncoded,
            EncodedSize = textEncoded.Length,
            OriginalSize = Huffman.GetBinarySize(req.TextToEncode)
        };

        foreach (var kvp in huffmanTable)
            resp.MatchingCharacters.Add(new Character { Id = kvp.Key.ToString(), Value = kvp.Value });

        return Results.Ok(resp);
    }
    catch (Exception e)
    {
        Log.Error(e, e.Message);
        return Results.BadRequest();
    }
})
.WithName("PostHuffmanEncode");

app.MapPost("/huffman/decode", (DecodeRequest req) =>
{
    try
    {
        var matchingTable = req.MatchingCharacters
            .Where(c => !string.IsNullOrEmpty(c.Id))
            .ToDictionary(c => c.Id![0], c => c.Value ?? string.Empty);

        var decodedText = Huffman.DecodeText(req.BinaryHuffman, matchingTable);
        return Results.Ok(new DecodeResponse { DecodedText = decodedText });
    }
    catch (Exception e)
    {
        Log.Error(e, e.Message);
        return Results.BadRequest();
    }
})
.WithName("PostHuffmanDecode");

app.MapFallbackToFile("/index.html");

await app.RunAsync();
