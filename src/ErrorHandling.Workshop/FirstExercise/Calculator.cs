// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Calculator.cs" company="bbv Software Services AG">
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

namespace ErrorHandling.Workshop.FirstExercise
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class Calculator
    {
        public const string NotDefinedOperation = "NDef";

        private readonly Collection<IOperator> operators;
        private readonly ILogger logger;

        private int lastSetNumber;
        private string lastSelectedOperation = NotDefinedOperation;

        public Calculator(ILogger logger)
        {
            this.logger = logger;
            this.operators = new Collection<IOperator>
            {
                new AdditionOperator(),
                new SubtractionOperator(),
            };
        }

        public int Result { get; private set; }

        public void SetNumber(int value)
        {
            this.lastSetNumber = value;
        }

        public void PerformOperation(string operation)
        {
            this.EnsureOperationSet(operation);

            this.Result = this.lastSelectedOperation != NotDefinedOperation
                ? this.Calculate(this.lastSelectedOperation, this.Result, this.lastSetNumber)
                : this.lastSetNumber;

            this.lastSelectedOperation = operation;
        }

        private void EnsureOperationSet(string operation)
        {
            if (operation == null)
            {
                this.logger.Log("invalid operation: null");

                throw new ArgumentNullException(nameof(operation));
            }

            if (string.IsNullOrEmpty(operation))
            {
                this.logger.Log("no operation set");

                throw new ArgumentException("no operation set");
            }
        }

        private int Calculate(string operation, int firstNumber, int secondNumber)
        {
            IOperator calculationOperator = this.operators.FirstOrDefault(x => x.CommandName == operation);

            this.EnsureOperationValid(calculationOperator, operation);

            return calculationOperator.Calculate(firstNumber, secondNumber);
        }

        private void EnsureOperationValid(IOperator calculationOperator, string operation)
        {
            if (calculationOperator != null)
            {
                return;
            }

            string errorMessage = string.Concat("there is no ", operation, " operation");

            this.logger.Log(errorMessage);

            throw new InvalidOperationException(errorMessage);
        }
    }
}
