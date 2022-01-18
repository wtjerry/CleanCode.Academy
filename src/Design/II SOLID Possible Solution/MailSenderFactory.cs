namespace CleanCode.Design.SolidSolution
{
    public class MailSenderFactory
    {
        private readonly bool testingMode;

        /// <summary>
        /// The parameter <paramref name="testingMode"/> determines if a real mail sender object should be
        /// generated or a fake one for testing purposes.
        /// </summary>
        /// <remarks>
        /// This is only a sample usage. In a real project you would distinguish between "real" factories and
        /// factories for automated testing. As our sample solution is already quite big, we will stick to this simple
        /// approach.
        /// </remarks>
        public MailSenderFactory(bool testingMode)
        {
            this.testingMode = testingMode;
        }

        public IMailSender Create()
        {
            if (this.testingMode)
            {
                return new FakeMailSender();
            }

            return new MailSender();
        }
    }
}