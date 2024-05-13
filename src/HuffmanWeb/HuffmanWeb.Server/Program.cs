using HuffmanWeb.Algorithm;
using HuffmanWeb.Server.DTOs;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapPost("/huffman/encode", ( EncodeRequest textToEncode) =>
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
    foreach(var key in huf.HuffmanTable.Keys)
    {
        resp.MatchingCharacters.Add(new Character() { Id = key.ToString(), Value = huf.HuffmanTable[key].ToString() });
    }
    return TypedResults.Ok(resp);
})
.WithName("PostHuffmanEncode")
.WithOpenApi();


app.MapFallbackToFile("/index.html");

app.UseCors(builder => builder
 .AllowAnyOrigin()
 .AllowAnyMethod()
 .AllowAnyHeader()
);

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
