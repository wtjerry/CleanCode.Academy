﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewCustomerTest.cs" company="bbv Software Services AG">
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

namespace CleanCode.Naming.UseNullObjects
{
    using FakeItEasy;
    using Xunit;

    public class NewCustomerTest
    {
        private readonly IMailDispatcher dispatcher;
        private readonly NewCustomer testee;

        public NewCustomerTest()
        {
            this.dispatcher = A.Fake<IMailDispatcher>();

            this.testee = new NewCustomer(this.dispatcher);
        }

        [Fact]
        public void SendsNewsletter()
        {
            this.testee.SendNewsletter();

            A.CallTo(() => this.dispatcher.Send("As a new customer you have 10% on your next order over 100$"))
                .MustHaveHappened();
        }
    }
}
