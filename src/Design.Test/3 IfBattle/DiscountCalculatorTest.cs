// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiscountCalculatorTest.cs" company="bbv Software Services AG">
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

namespace CleanCode.Naming.IfBattle
{
    using FluentAssertions;
    using Xunit;

    // TODO: Refactor the DiscountCalculator in a way that it allows adding more rules and then fix the failing test at the end!
    // Important: Make sure you do small steps. Don't let all your tests fail, use parallel implementation etc.
    public class DiscountCalculatorTest
    {
        private DiscountCalculator testee;

        public DiscountCalculatorTest()
        {
            this.testee = new DiscountCalculator();
        }

        [Fact]
        public void HasNoDiscount_WhenNewCustomer()
        {
            var order = new Order(new Customer(), 50);

            int discount = this.testee.CalculateDiscount(order);

            discount.Should().Be(0);
        }

        [Fact]
        public void Has5PercentDiscount_WhenCustomerIsRegularCustomer()
        {
            var customer = new Customer { NumberOfOrders = 10 };
            var order = new Order(customer, 0);

            int discount = this.testee.CalculateDiscount(order);

            discount.Should().Be(5);
        }

        [Fact]
        public void RegularCustomerHas2PercentExtraDiscount_WhenOrderIsWorth100OrMore()
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
        public void LargeAccountCustomerHas6PercentDiscount_WhenOrderIsLessThan200()
        {
            var customer = new Customer { NumberOfOrders = 1000 };
            var order = new Order(customer, 199);

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

        // TODO: Refactor before you make that test work!
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
