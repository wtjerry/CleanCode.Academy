// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LargeAccountCustomerDiscountStrategyTest.cs" company="bbv Software Services AG">
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
    using System;
    using FluentAssertions;
    using Xunit;

    public class LargeAccountCustomerDiscountStrategyTest
    {
        private LargeAccountCustomerDiscountStrategy testee;

        public LargeAccountCustomerDiscountStrategyTest()
        {
            this.testee = new LargeAccountCustomerDiscountStrategy();
        }

        [Fact]
        public void QualifiesForDiscount_WhenNumberOfOrdersIsGreaterOrEqualThan1000()
        {
            var customer = new Customer { NumberOfOrders = 1000 };

            bool qualifies = this.testee.QualifiesForDiscount(customer);

            qualifies.Should().BeTrue();
        }

        [Fact]
        public void DoesNotQualifyForDiscount_WhenNumberOfOrdersIsLessThan1000()
        {
            var customer = new Customer { NumberOfOrders = 999 };

            bool qualifies = this.testee.QualifiesForDiscount(customer);

            qualifies.Should().BeFalse();
        }

        [Fact]
        public void DiscountIs8Percent_WhenOrderIs200OrMore()
        {
            var customer = new Customer { NumberOfOrders = 1000 };
            var order = new Order(customer, 200);

            int discount = this.testee.CalculateDiscount(order);

            discount.Should().Be(8);
        }

        [Fact]
        public void DiscountIs6Percent_WhenOrderIsLessThan200()
        {
            var customer = new Customer { NumberOfOrders = 1000 };
            var order = new Order(customer, 199);

            int discount = this.testee.CalculateDiscount(order);

            discount.Should().Be(6);
        }

        [Fact]
        public void CannotCalculateDiscount_WhenCustomerDoesNotQualify()
        {
            var newCustomer = new Customer { NumberOfOrders = 5 };
            var order = new Order(newCustomer, 199);

            Action act = () => this.testee.CalculateDiscount(order);

            act.Should().Throw<InvalidOperationException>();
        }
    }
}
