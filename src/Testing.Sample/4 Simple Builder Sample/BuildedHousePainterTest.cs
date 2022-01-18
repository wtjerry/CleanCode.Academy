// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuildedHousePainterTest.cs" company="bbv Software Services AG">
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
    using System.Drawing;
    using System.Linq;

    using CleanCode.Testing.Sample.SampleImplementation;

    using FluentAssertions;
    using Xunit;

    public class BuildedHousePainterTest
    {
        private HousePainter testee;

        [Fact]
        public void PaintsFrontDoorOfHouse()
        {
            Color newColor = Color.DeepSkyBlue;

            House house = HouseBuilder.Create()
                .WithFrontDoorOfColor(Color.White)
                .Build();

            this.testee = new HousePainter(house);
            this.testee.ChangeColorOfFrontDoor(newColor);

            house.FrontDoor.Color.Should().Be(newColor);
        }

        [Fact]
        public void PaintsWindowBordersOfARoom()
        {
            Color newColor = Color.Maroon;

            var sampleWindow = new Window { BorderColor = Color.White };

            House house = HouseBuilder.Create()
                .AddFloor()
                    .AddRoom()
                        .WithWindow(sampleWindow)
                .Build();

            this.testee = new HousePainter(house);
            this.testee.ChangeBorderColorOfAllWindows(newColor);

            sampleWindow.BorderColor.Should().Be(newColor);
        }

        [Fact]
        public void PaintsAllWindowBorders()
        {
            Color newColor = Color.Lime;

            House house = HouseBuilder.Create()
                .AddFloor()
                    .WithRoomHavingWindowsQuantityOf(2)
                    .WithRoomHavingWindowsQuantityOf(1)
                    .WithRoomHavingWindowsQuantityOf(1)
                .AddFloor()
                    .WithRoomHavingWindowsQuantityOf(2)
                    .WithRoomHavingWindowsQuantityOf(2)
                    .WithRoomHavingWindowsQuantityOf(1)
                .Build();

            IReadOnlyCollection<Room> allRoomsOfFirstFloor = house.Floors.First().Rooms;
            IReadOnlyCollection<Room> allRoomsOfSecondFloor = house.Floors.Last().Rooms;

            this.testee = new HousePainter(house);
            this.testee.ChangeBorderColorOfAllWindows(newColor);

            allRoomsOfFirstFloor.Should().Match(rooms => rooms.All(r => r.Windows.All(w => w.BorderColor == newColor)));
            allRoomsOfSecondFloor.Should().Match(rooms => rooms.All(r => r.Windows.All(w => w.BorderColor == newColor)));
        }
    }
}
