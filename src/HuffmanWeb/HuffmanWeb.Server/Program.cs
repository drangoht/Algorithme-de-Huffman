using HuffmanWeb.Algorithm;
using HuffmanWeb.Server.DTOs;
using Microsoft.AspNetCore.Http;
using Serilog;

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



app.MapPost("/huffman/encode", (EncodeRequest textToEncode) =>
{
    try
    {
        var huf = new Huffman();
        huf.EncodeText(textToEncode.TextToEncode);
        TextToEncodeResponse resp = new TextToEncodeResponse()
        {
            Graph = huf.GeneratedGraph,
            EncodedBinaryString = huf.TextEncoded,
            EncodedSize = huf.InputHuffmanBinarySize,
            OriginalSize = huf.InputBinarySize
        };
        foreach (var key in huf.HuffmanTable.Keys)
        {
            resp.MatchingCharacters.Add(new Character() { Id = key.ToString(), Value = huf.HuffmanTable[key].ToString() });
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


app.MapFallbackToFile("/index.html");



app.Run();

