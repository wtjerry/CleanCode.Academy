namespace CleanCode.Naming.ImmutableObjects
{
    using System.Collections.Generic;
    using FakeItEasy;
    using Xunit;

    // What about the 'Windows 8' that are boxed? DeliveryService.cs:Line 16
    // What about the change of the delivery address before sending the package?
    // TODO: Refactor the Order and Position so that objects of these types are immutable (read-only).
    // TODO: Reduce the interface of IBoxingService.Box(Order) to a minimum
    //
    // -->
    // Windows 8 was actually an error
    // IBoxingService can be reduced to positions, doesnt need to know adress
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
            var positions = new List<Position>
            {
                new("Visual Studio", 3),
                new("ReSharper", 2)
            };
            var order = new Order("bbv Software Serivces AG; Luzern", positions);

            var parcel = new Parcel();
            A.CallTo(() => this.boxingService.Box(positions)).Returns(parcel);

            this.testee.Deliver(order);

            A.CallTo(() => this.mailService.Deliver(order.Address, parcel)).MustHaveHappened();
        }
    }
}
