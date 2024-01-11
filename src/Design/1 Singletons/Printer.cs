// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Printer.cs" company="bbv Software Services AG">
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

namespace CleanCode.Naming.Singletons
{
    using System;

    public class Printer
    {
        private static Printer instance;
        private readonly string data;

        public Printer()
        {
            this.data = "someVeryImportantDataThatTheServiceRequires";
        }

        public static Printer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Printer();
                }

                return instance;
            }
        }

        public void Print(Invoice invoice)
        {
            Console.WriteLine(this.data);
            Console.WriteLine($"Pretend that this line actually prints the invoice. Date: {invoice.Date}");
        }
    }
}
