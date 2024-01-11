// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Persistence.cs" company="bbv Software Services AG">
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

namespace CleanCode.Naming.PersistingEnums
{
    using System;
    using System.Collections.Generic;

    public class Persistence
    {
        private readonly Dictionary<string, Person> store;

        public Persistence()
        {
            this.store = [];
        }

        public void Save(Person person)
        {
            this.store[person.Name] = person;

            // imagine this method saves the person like this (obviously not exactly like this, because of Sql injection)
            var sql = $"""
               INSERT INTO Person
               (
                   Name,
                   Title
               )
               VALUES
               (
                   {person.Name},
                   {person.Title} -- hint: this might be an issue
               );
            """;
            Console.WriteLine(sql);
        }

        public Person Load(string name)
        {
            return this.store[name];
        }
    }
}
