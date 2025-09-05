var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();


app.MapGet("/aesencryption", (string algoritmo, string text) =>
{
    return new AesEncryption().Encryption(algoritmo,text);
})
.WithOpenApi();




app.MapGet("/aesdecryption", (string algoritmo, string text) =>
{
    return new AesDecryption().Decryption(algoritmo,text);
})
.WithOpenApi();
app.Run();

