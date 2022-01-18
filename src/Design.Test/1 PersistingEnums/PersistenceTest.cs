// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersistenceTest.cs" company="bbv Software Services AG">
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
    using FluentAssertions;
    using Xunit;

    // TODO: Make sure you can easily add a new 'Title' and don't get into trouble when you rename the title (e.g. Ms to Miss) just in your code without affecting
    // existing records in your database (We know it's In-Memory in this code, but use your imagination here and think of it as being a real persistent database with
    // millions of records)
    public class PersistenceTest
    {
        private Persistence testee;

        public PersistenceTest()
        {
            this.testee = new Persistence();
        }

        [Fact]
        public void StoresAPerson()
        {
            const string Name = "Clean Coder";
            var person = new Person { Name = Name, Title = Title.Sir };

            this.testee.Save(person);
            Person loadedPerson = this.testee.Load(Name);

            loadedPerson.Should().BeEquivalentTo(new Person { Name = person.Name, Title = person.Title });
        }
    }
}
