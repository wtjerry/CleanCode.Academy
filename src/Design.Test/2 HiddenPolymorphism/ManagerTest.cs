﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ManagerTest.cs" company="bbv Software Services AG">
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

namespace CleanCode.Design.HiddenPolymorphism
{
    using FluentAssertions;
    using Xunit;

    public class ManagerTest
    {
        [Fact]
        public void HasBonus()
        {
            const int MonthlySalary = 7000;
            const int Bonus = 1000;

            var manager = new Manager(MonthlySalary, Bonus);
            int salaryToPay = manager.CalculateSalary();

            salaryToPay.Should().Be(MonthlySalary + Bonus);
        }
    }
}
