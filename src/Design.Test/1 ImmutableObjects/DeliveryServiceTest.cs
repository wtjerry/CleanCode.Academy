namespace CleanCode.Naming.ImmutableObjects
{
    using FakeItEasy;
    using Xunit;

    // What about the 'Windows 8' that are boxed? DeliveryService.cs:Line 16
    // What about the change of the delivery address before sending the package?
    // TODO: Refactor the Order and Position so that objects of these types are immutable (read-only).
    // TODO: Reduce the interface of IBoxingService.Box(Order) to a minimum
    public class DeliveryServiceTest
    {
        private DeliveryService testee;
        private IMailService mailService;
        private IBoxingService boxingService;

        public DeliveryServiceTest()
        {
            this.mailService = A.Fake<IMailService>();
            this.boxingService = A.Fake<IBoxingService>();

            this.testee = new DeliveryService(this.mailService, this.boxingService);
        }

        [Fact]
        public void SendsTheBoxedOrderByMail()
        {
            var order = new Order { Address = "bbv Software Serivces AG; Luzern" };
            order.Positions.Add(new Position { Item = "Visual Studio", Amount = 3 });
            order.Positions.Add(new Position { Item = "ReSharper", Amount = 2 });

            var parcel = new Parcel();
            A.CallTo(() => this.boxingService.Box(order)).Returns(parcel);

            this.testee.Deliver(order);

            A.CallTo(() => this.mailService.Deliver(order.Address, parcel)).MustHaveHappened();
        }
    }
}
