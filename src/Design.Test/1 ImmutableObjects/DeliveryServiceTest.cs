namespace CleanCode.Naming.ImmutableObjects
{
    using FakeItEasy;
    using Xunit;

    // hmm.. it looks like somebody made a mistake in DeliveryService.Deliver
    // and left some code in that was only meant for debug
    // (adding a Position 'Windows 8' and appending Switzerland to the address)
    // TODO: remove the mistakenly added code
    // TODO: while you're at it: refactor the Order and Position so that objects of these types are immutable (read-only).
    // TODO: reduce the interface of IBoxingService.Box(Order) to a minimum (hint: does IBoxingService really need to know about addresses?)
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
