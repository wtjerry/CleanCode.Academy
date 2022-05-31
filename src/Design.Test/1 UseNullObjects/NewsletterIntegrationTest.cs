﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewsletterIntegrationTest.cs" company="bbv Software Services AG">
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

    // Null the billion dollar mistake (maybe even trillion now?)
    // A lot of code uses null as a placeholder, dummy initializer, special value, value meaning nothing is there...
    // And if we just forget to check for null in one place, our program starts yelling at us, or even worse our customers.
    // TODO: Refactor the system (UseNullObjects namespace) in a way that the 'if' statement in the NewsletterService is no longer required! Use a Null object implementation
    // A Null object is an object with defined neutral ("null") behavior (see: http://en.wikipedia.org/wiki/Null_Object_pattern)
    // TODO: Remember to also remove tests that are no longer required if there are any
    public class NewsletterIntegrationTest
    {
        private IMailDispatcher mailDispatcher;
        private NewsletterService testee;

        public NewsletterIntegrationTest()
        {
            this.mailDispatcher = A.Fake<IMailDispatcher>();

            this.testee = new NewsletterService(new SimpleCustomerFinder(this.mailDispatcher));
        }

        [Fact]
        public void SendsNewsletterToKnownCustomers()
        {
            const string Bbv = "bbv";
            const string BbvIct = "bbv ICT";
            const string UnknownCustomer = "not a customer";

            var customers = new[] { Bbv, BbvIct, UnknownCustomer };
            this.testee.SendNewsToCustomers(customers);

            A.CallTo(() => this.mailDispatcher.Send("As a large account customer you receive 5% back when you have a monthly volume of more than 1000$ in April 2013."))
                .MustHaveHappenedOnceExactly();

            A.CallTo(() => this.mailDispatcher.Send("As a new customer you have 10% on your next order over 100$"))
                .MustHaveHappenedOnceExactly();
        }
    }
}
