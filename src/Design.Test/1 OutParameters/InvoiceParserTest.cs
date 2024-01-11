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

namespace CleanCode.Naming.OutParameters;

using FluentAssertions;
using System;
using System.Globalization;
using System.Xml.Linq;
using Xunit;

// out parameters is sometimes used if a method should return 2 "things".
// since ~c#7 it would also be possible to return a tuple instead of using out parameters.
// there is also the possibility to return a type that can represent failure (without value) or success with value.
// TODO: Refactor the code so that you don't have an 'out' parameter anymore. But don't return 'null' when you cannot parse the invoice!
// Hint: use a Result object
public class InvoiceParserTest
{
    [Fact]
    public void ParsesInvoice()
    {
        const string Customer = "bbv Software Services AG";
        const int Amount = 1200;

        var parsingSuccessful = InvoiceParser.TryParse(CreateInvoice(Customer, Amount), out var invoice);

        parsingSuccessful.Should().BeTrue();
        invoice.Should().BeEquivalentTo(new Invoice(Customer, Amount));
    }

    [Fact]
    public void ReturnsTrue_WhenInvoiceCanBeParsed()
    {
        const string Customer = "bbv Software Services AG";
        const int Amount = 1200;

        var result = InvoiceParser.TryParse(CreateInvoice(Customer, Amount), out _);

        result.Should().BeTrue();
    }

    [Theory]
    [InlineData("", "100")]
    [InlineData("bbv", "")]
    public void InvoiceIsNull_WhenInvoiceCannotBeParsed(string customer, string amount)
    {
        _ = InvoiceParser.TryParse(CreateInvoice(customer, amount), out var invoice);

        invoice.Should().BeNull();
    }

    [Theory]
    [InlineData("", "100")]
    [InlineData("bbv", "")]
    public void ReturnsFalse_WhenInvoiceCannotBeParsed(string customer, string amount)
    {
        var result = InvoiceParser.TryParse(CreateInvoice(customer, amount), out _);

        result.Should().BeFalse();
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
        return CreateInvoice(customer, Convert.ToString(amount, CultureInfo.InvariantCulture));
    }
}
