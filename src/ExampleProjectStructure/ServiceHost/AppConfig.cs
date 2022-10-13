namespace CleanCode.Academy.ServiceHost
{
    public record AppConfig(
        bool IsFeatureCombinePositionsEnabled,
        int SomeOtherConfig,
        bool UseInMemoryDatabase);
}
