// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HousePainterTest.cs" company="bbv Software Services AG">
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

namespace CleanCode.Testing.Sample
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Drawing;
    using System.Linq;
    using System.Xml.Linq;

    using CleanCode.Testing.Sample.Implementation;

    using FluentAssertions;

    using Xunit;

    public class HousePainterTest
    {
        [Fact]
        public void PaintsTheRoof()
        {
            Color newColor = Color.Red;
            HousePainter testee = CreateTestee();

            testee.ChangeColorOfRoof(newColor);
            XDocument result = testee.GetResult();

            result.RoofElement().ColorAttributeValue().Should().Be(newColor);
        }

        [Fact]
        public void PaintsTheDoor()
        {
            Color newColor = Color.RoyalBlue;
            HousePainter testee = CreateTestee();

            testee.ChangeColorOfFrontDoor(newColor);
            XDocument result = testee.GetResult();

            result.FrontDoorElement().ColorAttributeValue().Should().Be(newColor);
        }

        [Fact]
        public void PaintsTheFacade()
        {
            Color newColor = Color.FromArgb(250, 240, 232);
            HousePainter testee = CreateTestee();

            testee.ChangeColorOfFacade(newColor);
            XDocument result = testee.GetResult();

            result.FacadeColorElementValue().Should().Be(newColor);
        }

        [Fact]
        public void PaintsTheWindowBorders()
        {
            Color newColor = Color.FromArgb(10, 15, 72);
            HousePainter testee = CreateTestee();

            testee.ChangeBorderColorOfAllWindows(newColor);
            ICollection<XElement> result = testee.GetResult().WindowElements();

            result.First().ColorAttributeValue().Should().Be(newColor);
            result.Last().ColorAttributeValue().Should().Be(newColor);
        }

        private static HousePainter CreateTestee()
        {
            return new HousePainter(CreateSampleHouseWith2Windows());
        }

        private static House CreateSampleHouseWith2Windows()
        {
            return new House
            {
                FacadeColor = Color.Gray,
                FrontDoor = new FrontDoor { Color = Color.Gray, Height = 2.1d, Width = 1d },
                Height = 5,
                NumberOfFloors = 2,
                Roof = new Roof { Color = Color.Gray, Size = 100d },
                Width = 15,
                Windows = new Collection<Window>
                {
                    new Window { BorderColor = Color.Gray, Dimension = new SizeF(1, 1.4f) },
                    new Window { BorderColor = Color.Gray, Dimension = new SizeF(1, 1.4f) }
                }
            };
        }
    }
}
