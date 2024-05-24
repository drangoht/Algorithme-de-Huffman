using HuffmanWeb.Algorithm;
using HuffmanWeb.Common.DTOs;
using HuffmanWeb.Common.DTOs.Requests;
using HuffmanWeb.Common.DTOs.Responses;
using Serilog;
using System.Collections;

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
builder.Services.AddSwaggerGen();

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
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapPost("/huffman/encode", (EncodeRequest req) =>
{
    try
    {
        var nodes = Huffman.GetNodesFromString(req.TextToEncode);
        var graph = Huffman.GenerateHuffmanGraph(nodes);
        var textEncoded = Huffman.EncodeText(req.TextToEncode);
        EncodeResponse resp = new EncodeResponse()
        {
            Graph = graph,
            EncodedBinaryString = textEncoded,
            EncodedSize = textEncoded.Length,
            OriginalSize = Huffman.GetBinarySize(req.TextToEncode)
        };

        var huffmanTable = Huffman.MakeMatchingTable(req.TextToEncode);
        foreach (var key in huffmanTable.Keys)
        {
            resp.MatchingCharacters.Add(new Character() { Id = key.ToString(), Value = huffmanTable[key].ToString() });
        }

        return Results.Ok(resp);
    }
    catch (Exception e)
    {
        Log.Error(e.Message);
        return Results.BadRequest();
    }


})
.WithName("PostHuffmanEncode")
.WithOpenApi();

app.MapPost("/huffman/decode", (DecodeRequest req) =>
{
    try
    {
        Hashtable matchingCharactersTable = new Hashtable();
        foreach (var item in req.MatchingCharacters)
        {
            matchingCharactersTable.Add(item.Id, item.Value);
        }

        var decodedText = Huffman.DecodeText(req.BinaryHuffman, matchingCharactersTable);
        DecodeResponse resp = new DecodeResponse()
        {
            DecodedText = decodedText,
        };
        return Results.Ok(resp);
    }
    catch (Exception e)
    {
        Log.Error(e.Message);
        return Results.BadRequest();
    }


})
.WithName("PostHuffmanDecode")
.WithOpenApi();

app.MapFallbackToFile("/index.html");



app.Run();

