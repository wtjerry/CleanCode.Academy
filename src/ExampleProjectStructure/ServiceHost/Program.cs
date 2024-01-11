namespace CleanCode.Academy.ServiceHost;

using Database.InMemory;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

public static class Program
{
    public static void Main()
    {
        var appConfig = AppConfigReader.Read();

        if (!appConfig.UseInMemoryDatabase)
        {
            throw new NotImplementedException(
                "This service is not yet Production ready. So far it only supports in memory persistence");
        }

        var builder = WebApplication.CreateBuilder();
        builder.Services.AddSingleton(
            Factory.CreateForInMemoryRepositoryUsage(
                appConfig,
                new InMemoryPersistence()));

        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.UseRouting();

        app.MapControllers();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.Run();
    }
}
