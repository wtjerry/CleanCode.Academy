namespace CleanCode.Academy.ServiceHost;

using Core.CreateOrder;
using Core.GetOrders;
using Database.InMemory;
using System;

public class Factory
{
    private readonly AppConfig appConfig;
    private readonly IQuery query;
    private readonly IModifier modifier;
    private readonly IOrderCreatedPublisher orderCreatedPublisher;

    public Factory(
        AppConfig appConfig,
        IQuery query,
        IModifier modifier,
        IOrderCreatedPublisher orderCreatedPublisher)
    {
        this.appConfig = appConfig;
        this.query = query;
        this.modifier = modifier;
        this.orderCreatedPublisher = orderCreatedPublisher;
    }

    public static Factory CreateForInMemoryRepositoryUsage(
        AppConfig config,
        InMemoryPersistence inMemoryPersistence) =>
        new(
            config,
            new Query(inMemoryPersistence),
            new Modifier(
                inMemoryPersistence,
                new Random()),
            new OrderCreatedPublisher());

    public CreateOrderFeature CreateCreateOrderFeature() =>
        new(
            new CreateOrderFeatureFlagConfig(this.appConfig.IsFeatureCombinePositionsEnabled),
            this.modifier,
            this.orderCreatedPublisher);

    public GetOrdersFeature CreateGetOrdersFeature() =>
        new(this.query);
}
