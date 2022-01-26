// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewCustomerDiscountStrategyTest.cs" company="bbv Software Services AG">
//   Copyright (c) 2014
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

namespace CleanCode.Naming.IfBattle
{
    using FluentAssertions;
    using Xunit;

    public class NewCustomerDiscountStrategyTest
    {
        private NewCustomerDiscountStrategy testee;

        public NewCustomerDiscountStrategyTest()
        {
            this.testee = new NewCustomerDiscountStrategy();
        }

        [Fact]
        public void EveryoneQualifiesForDiscount()
        {
            bool qualifies = this.testee.QualifiesForDiscount(new Customer { NumberOfOrders = 0 });

            qualifies.Should().BeTrue();
        }

        [Fact]
        public void DiscountIs1Percent_WhenOrderIs200OrMore()
        {
            var customer = new Customer { NumberOfOrders = 0 };
            var order = new Order(customer, 200);

            int discount = this.testee.CalculateDiscount(order);

            discount.Should().Be(1);
        }

        [Fact]
        public void RetailSurchargeIs2Percent_WhenOrderIsWorthLessThan30()
        {
            var customer = new Customer { NumberOfOrders = 0 };
            var order = new Order(customer, 29);

            int discount = this.testee.CalculateDiscount(order);

            discount.Should().Be(-2);
        }

        [Theory]
        [InlineData(30)]
        [InlineData(31)]
        [InlineData(199)]
        public void NoDiscount_WhenOrderIs30OrMoreAndLessThan200(int orderValue)
        {
            var customer = new Customer { NumberOfOrders = 0 };
            var order = new Order(customer, orderValue);

            int discount = this.testee.CalculateDiscount(order);

            discount.Should().Be(0);
        }
    }
}
