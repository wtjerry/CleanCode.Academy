namespace CleanCode.Academy.ServiceHost;

using System;
using Database.InMemory;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

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
        var app = builder.Build();

        app.UseRouting();

        app.Run();
    }
}
