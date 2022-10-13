namespace CleanCode.Academy.ServiceHost;

using Microsoft.Extensions.Configuration;

internal static class AppConfigReader
{
    internal static AppConfig Read()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appSettings.json")
            .Build();

        var isFeatureCombinePositionsEnabled = config.GetValue<bool>("AppSettings:IsFeatureCombinePositionsEnabled");
        var someOtherConfig = config.GetValue<int>("AppSettings:SomeOtherConfig");
        var useInMemoryDatabase = config.GetValue<bool>("AppSettings:UseInMemoryDatabase");

        return new AppConfig(
            isFeatureCombinePositionsEnabled,
            someOtherConfig,
            useInMemoryDatabase);
    }
}
