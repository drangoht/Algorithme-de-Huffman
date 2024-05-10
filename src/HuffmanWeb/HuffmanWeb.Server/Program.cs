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
        encodedBinaryString = huf.TextDecoded,
        encodedSize = huf.InputHuffmanBinarySize,
        originalSize = huf.InputBinarySize
    };
    foreach(var key in huf.HuffmanTable.Keys)
    {
        resp.MatchingCharacters.Add(new Tuple<string, string>(key.ToString(), huf.HuffmanTable[key].ToString()));
    }
    return TypedResults.Ok(resp);
})
.WithName("PostHuffmanEncode")
.WithOpenApi();



app.MapPost("/huffman/{textToEncode}/encodedecode", (string textToEncode) =>
{
    var huf = new Huffman();
    huf.EncodeAndDecodeText(textToEncode);
    return TypedResults.Ok($" Text decoded : {huf.TextDecoded}");
});

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
