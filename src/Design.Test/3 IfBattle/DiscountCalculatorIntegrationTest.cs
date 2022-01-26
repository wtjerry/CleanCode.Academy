// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiscountCalculatorIntegrationTest.cs" company="bbv Software Services AG">
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

    public class DiscountCalculatorIntegrationTest
    {
        private DiscountCalculator testee;

        public DiscountCalculatorIntegrationTest()
        {
            this.testee = new DiscountCalculator(new IDiscountStrategy[]
                {
                    new LargeAccountCustomerDiscountStrategy(),
                    new RegularCustomerDiscountStrategy(),
                    new NewCustomerDiscountStrategy(),
                });
        }

        [Fact]
        public void HasNoDiscount_WhenNewCustomer()
        {
            var order = new Order(new Customer(), 50);

            int discount = this.testee.CalculateDiscount(order);

            discount.Should().Be(0);
        }

        [Fact]
        public void Has5PercentDiscount_WhenCustomerIsGoodCustomer()
        {
            var customer = new Customer { NumberOfOrders = 10 };
            var order = new Order(customer, 0);

            int discount = this.testee.CalculateDiscount(order);

            discount.Should().Be(5);
        }

        [Fact]
        public void GoodCustomerHas2PercentExtraDiscount_WhenOrderIsWorth100OrMore()
        {
            var customer = new Customer { NumberOfOrders = 10 };
            var order = new Order(customer, 100);

            int discount = this.testee.CalculateDiscount(order);

            discount.Should().Be(7);
        }

        [Fact]
        public void NewCustomerHas1PercentDiscount_WhenOrderIsWorth200OrMore()
        {
            var customer = new Customer();
            var order = new Order(customer, 200);

            int discount = this.testee.CalculateDiscount(order);

            discount.Should().Be(1);
        }

        [Fact]
        public void NewCustomerPays2PercentExtra_WhenOrderIsWorthLessThan30()
        {
            var customer = new Customer();
            var order = new Order(customer, 29);

            int discount = this.testee.CalculateDiscount(order);

            discount.Should().Be(-2);
        }

        [Fact]
        public void LargeAccountCustomerHas6PercentDiscount_WhenOrderIsLessThan100()
        {
            var customer = new Customer { NumberOfOrders = 1000 };
            var order = new Order(customer, 99);

            int discount = this.testee.CalculateDiscount(order);

            discount.Should().Be(6);
        }

        [Fact]
        public void LargeAccountCustomerHas8PercentDiscount_WhenOrderIsWorth200OrMore()
        {
            var customer = new Customer { NumberOfOrders = 1000 };
            var order = new Order(customer, 200);

            int discount = this.testee.CalculateDiscount(order);

            discount.Should().Be(8);
        }

        [Fact]
        public void LargeAccountCustomerAlwaysGetsTheBestDiscount()
        {
            var customer = new Customer { NumberOfOrders = 1000 };
            var order = new Order(customer, 150);

            int discount = this.testee.CalculateDiscount(order);

            discount.Should().Be(7);
        }
    }
}
