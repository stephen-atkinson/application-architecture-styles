using DonutShop.Api;
using DonutShop.Api.Features;
using DonutShop.Api.Shared.Database;
using DonutShop.Api.Shared.Files;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFeatures(builder.Configuration);
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddFiles();
builder.Services.AddWeb(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseExceptionHandler();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers().RequireAuthorization();

app.Run();