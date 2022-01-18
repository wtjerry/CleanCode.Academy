// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FirstCalculatorTest.cs" company="bbv Software Services AG">
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

namespace ErrorHandling.Test.Workshop
{
    using System;

    using ErrorHandling.Workshop.FirstExercise;

    using FluentAssertions;

    using Xunit;

    public class FirstCalculatorTest
    {
        private Calculator testee;

        private LoggerStub loggerStub;

        public FirstCalculatorTest()
        {
            this.loggerStub = new LoggerStub();

            this.testee = new Calculator(this.loggerStub);
        }

        [Fact]
        public void CalculatesSimpleAddition()
        {
            this.testee.SetNumber(2);
            this.testee.PerformOperation(AdditionOperator.Name);
            this.testee.SetNumber(4);
            this.testee.PerformOperation(EndOperator.Name);

            int result = this.testee.Result;

            result.Should().Be(6, "we calculated 2+4");
        }

        [Fact]
        public void CalculatesSimpleSubtraction()
        {
            this.testee.SetNumber(12);
            this.testee.PerformOperation(SubtractionOperator.Name);
            this.testee.SetNumber(4);
            this.testee.PerformOperation(EndOperator.Name);

            int result = this.testee.Result;

            result.Should().Be(8, "we calculated 12-4");
        }

        [Fact]
        public void Logs_WhenOperationEmpty()
        {
            const string EmptyOperationCommandName = "";

            this.testee.Invoking(x => x.PerformOperation(EmptyOperationCommandName)).Should().Throw<Exception>();

            this.loggerStub.LoggedMessages.Should().Contain(x => x.Contains("no operation set"));
        }

        [Fact]
        public void ThrowsArgumentException_WhenOperationEmpty()
        {
            const string EmptyOperationCommandName = "";

            Action act = () => this.testee.PerformOperation(EmptyOperationCommandName);

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Logs_WhenOperationNull()
        {
            this.testee.Invoking(x => x.PerformOperation(null)).Should().Throw<Exception>();

            this.loggerStub.LoggedMessages.Should().Contain(x => x.Contains("operation") && x.Contains("null"));
        }

        [Fact]
        public void ThrowsArgumentNullException_WhenOperationNull()
        {
            Action act = () => this.testee.PerformOperation(null);

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Logs_WhenOperationNotFound()
        {
            const string PowerOperationCommandName = "Pow";

            this.testee.SetNumber(5);
            this.testee.PerformOperation(PowerOperationCommandName);
            this.testee.SetNumber(3);
            this.testee.Invoking(x => x.PerformOperation(PowerOperationCommandName)).Should().Throw<Exception>();

            this.loggerStub.LoggedMessages.Should().Contain(x => x.Contains("no Pow operation"));
        }

        [Fact]
        public void ThrowsInvalidOperationException_WhenPowerOperationNotFound()
        {
            const string PowerOperationCommandName = "Pow";

            this.testee.SetNumber(5);
            this.testee.PerformOperation(PowerOperationCommandName);
            this.testee.SetNumber(3);
            Action act = () => this.testee.PerformOperation(EndOperator.Name);

            act.Should().Throw<InvalidOperationException>();
        }
    }
}
