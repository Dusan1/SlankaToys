using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SlankaToys.API.Config;
using SlankaToys.Application.Contracts;
using SlankaToys.Infrastructure;
using SlankaToys.Infrastructure.Repository;
using SlankaToys.Infrastructure.UnitOfWork;

string AllowSpecificOrigins = "_allowUISpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ICartRepository, CartRepository>();
builder.Services.AddTransient<ICartQueryRepository, CartQueryRepository>();
builder.Services.AddTransient<IProductQueryRepository, ProductQueryRepository>();

builder.Services.AddParamoreDarker();
builder.Services.RegisterParamoreBrighterCommands();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SlankaToys.API", Version = "v1" });
});

string connectionStringSql = builder.Configuration.GetConnectionString("SlankaToysConnectionString");
string connectionStringSqlite = builder.Configuration.GetConnectionString("SlankaToysConnectionStringSqlite");
string provider = builder.Configuration["DbProvider"];

//builder.Services.AddDbContext<SlankaToysDbContext>(opt =>
//    opt.UseSqlite("Filename=./SlankaToysDb.sqlite")
//    //opt.UseSqlServer(connectionString)
//);

builder.Services.AddDbContext<SlankaToysDbContext>(
                    options => _ = provider switch
                    {
                        "Sqlite" => options.UseSqlite(
                            connectionStringSqlite),

                        "Sql" => options.UseSqlServer(
                            connectionStringSql),

                        _ => throw new Exception($"Unsupported provider: {provider}")
                    });

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSpecificOrigins,
        builder =>
        {
            //builder.WithOrigins("https://localhost:47699");//local UI
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

builder.Services.AddApplicationInsightsTelemetry();
    
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SlankaToys.API v1"));
}

//context.Database.Migrate();

using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<SlankaToysDbContext>();
    context.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(AllowSpecificOrigins);

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();

    

