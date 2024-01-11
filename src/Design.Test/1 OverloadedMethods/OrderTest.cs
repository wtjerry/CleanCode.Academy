// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderTest.cs" company="bbv Software Services AG">
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

namespace CleanCode.Naming.OverloadedMethods
{
    using FluentAssertions;
    using Xunit;

    // Sometimes we have data which is used in different ways in different places.
    // This is the case here: we have a Position, but cannot / don't want to always provide a color.
    // That's why it has overloaded methods with some default values.
    // With that comes a new problem, however: it's more difficult to keep track which overload calls which method
    // and which methods might not even be used anymore.
    // TODO: Remove the overload with the signature 'AddPosition(string articleNumber, int amount, string size)' as it is never used
    // TODO: Refactor the 'Order' class in a way that you have to change the minimum possible amount of code when you remove another overload in the future
    public class OrderTest
    {
        private readonly Order testee;

        public OrderTest()
        {
            this.testee = new Order();
        }

        [Fact]
        public void AddsPositionToOrder()
        {
            const string ArticleNumber = "A12B";
            const int Amount = 2;
            const string Size = "Large";
            const string Color = "White";

            this.testee.AddPosition(ArticleNumber, Amount, Size, Color);

            this.testee.Positions.Should().Contain(x =>
                x.ArticleNumber == ArticleNumber
                && x.Amount == Amount
                && x.Size == Size
                && x.Color == Color);
        }

        [Fact]
        public void AddsPositionToOrderWithAmountOfOne_WhenAmountIsNotSpecified()
        {
            const string ArticleNumber = "A12B";

            this.testee.AddPosition(ArticleNumber);

            this.testee.Positions.Should().Contain(x =>
                x.ArticleNumber == ArticleNumber
                && x.Amount == 1);
        }

        [Fact]
        public void AddsPositionToOrderWithAmountAndNoSize_WhenSizeIsNotSpecified()
        {
            const string ArticleNumber = "A12B";
            const int Amount = 3;

            this.testee.AddPosition(ArticleNumber, Amount);

            this.testee.Positions.Should().Contain(x =>
                x.ArticleNumber == ArticleNumber
                && x.Amount == Amount
                && x.Size == string.Empty);
        }
    }
}
