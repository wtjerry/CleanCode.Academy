// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvoiceParserTest.cs" company="bbv Software Services AG">
//   Copyright (c) 2014 - 2020
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCode.Naming.OutParameters
{
    using System;
    using System.Xml.Linq;
    using Xunit;
    using static CleanCode.Naming.MaybeExtensions;

    // TODO: Refactor the code so that you don't have an 'out' parameter anymore. But don't return 'null' when you cannot parse the invoice!
    // Hint: use a Result object
    public class InvoiceParserTest
    {
        private InvoiceParser testee;

        public InvoiceParserTest()
        {
            this.testee = new InvoiceParser();
        }

        [Fact]
        public void ParsesInvoice()
        {
            const string Customer = "bbv Software Services AG";
            const int Amount = 1200;

            var maybeInvoice = this.testee.Parse(CreateInvoice(Customer, Amount));

            maybeInvoice.Should().BeSome(new Invoice(Customer, Amount));
        }

        [Theory]
        [InlineData("", "100")]
        [InlineData("bbv", "")]
        public void InvoiceIsNone_WhenInvoiceCannotBeParsed(string customer, string amount)
        {
            var maybeInvoice = this.testee.Parse(CreateInvoice(customer, amount));

            maybeInvoice.Should().BeNone();
        }

        private static XDocument CreateInvoice(string customer, string amount)
        {
            var invoice = new XDocument();
            var root = new XElement("Invoice");
            invoice.Add(root);

            root.Add(new XElement("Customer", customer));
            root.Add(new XElement("Amount", amount));

            return invoice;

        }

        private static XDocument CreateInvoice(string customer, int amount)
        {
            return CreateInvoice(customer, Convert.ToString(amount));
        }
    }
}
