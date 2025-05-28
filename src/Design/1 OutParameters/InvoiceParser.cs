// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvoiceParser.cs" company="bbv Software Services AG">
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
    using static CleanCode.Naming.Maybe2<Invoice>;
    using static CleanCode.Naming.Result<string, Invoice>;

    public static class InvoiceParser
    {
        public static Maybe2<Invoice> ParseInvoice(XDocument invoiceDescription)
        {
            var invoiceElement = invoiceDescription.Element("Invoice");
            var customerElement = invoiceElement.Element("Customer");
            var amountElement = invoiceElement.Element("Amount");

            if (!IsInvoiceValid(customerElement, amountElement))
            {
                return new Nothing<Invoice>();
            }

            var invoice = new Invoice(customerElement.Value, Convert.ToInt32(amountElement.Value));
            return new Just<Invoice>(invoice);
        }

        public static Result<string, Invoice> ParseInvoice2(XDocument invoiceDescription)
        {
            var invoiceElement = invoiceDescription.Element("Invoice");
            var customerElement = invoiceElement.Element("Customer");
            var amountElement = invoiceElement.Element("Amount");

            if (!IsInvoiceValid(customerElement, amountElement))
            {
                return new Error<string>("error");
            }

            var invoice = new Invoice(customerElement.Value, Convert.ToInt32(amountElement.Value));
            return new Success<Invoice>(invoice);
        }

        private static bool IsInvoiceValid(XElement customerElement, XElement amountElement)
        {
            return customerElement != null
                   && !string.IsNullOrEmpty(customerElement.Value)
                   && amountElement != null
                   && int.TryParse(amountElement.Value, out _);
        }
    }
}
