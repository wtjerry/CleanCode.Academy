namespace CleanCode.Academy.Core.CreateOrder;

// can be created at startup or at request time (bc a new feature is created each request)
public record CreateOrderFeatureFlagConfig(
    bool IsFeatureCombinePositionsEnabled);
