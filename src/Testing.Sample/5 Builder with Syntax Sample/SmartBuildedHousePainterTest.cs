// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SmartBuildedHousePainterTest.cs" company="bbv Software Services AG">
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

    using CleanCode.Testing.Sample.Builder;
    using CleanCode.Testing.Sample.SameImplementation;

    using FluentAssertions;

    using Xunit;

    public class SmartBuildedHousePainterTest
    {
        [Fact]
        public void PaintsWindowBordersOfASmallHouse()
        {
            Color newColor = Color.OrangeRed;

            House house = HouseBuilderWithSyntax.Create()
                .WithFrontDoorOfColor(Color.Gray)
                .AddFloor()
                    .AddRoom()
                        .AddWindowWithBorderColor(Color.Gray)
                .Build();

            Window onlyWindowInHouse = house.Floors.Single().Rooms.Single().Windows.Single();

            var testee = new HousePainter(house);
            testee.ChangeBorderColorOfAllWindows(newColor);

            onlyWindowInHouse.BorderColor.Should().Be(newColor);
        }

        [Fact]
        public void PaintsWindowBordersOfALargeHouse()
        {
            Color newColor = Color.Lime;

            House house = HouseBuilderWithSyntax.Create()
                .WithFrontDoorOfColor(Color.Gray)
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

            var testee = new HousePainter(house);
            testee.ChangeBorderColorOfAllWindows(newColor);

            allRoomsOfFirstFloor.Should().Match(rooms => rooms.All(r => r.Windows.All(w => w.BorderColor == newColor)));
            allRoomsOfSecondFloor.Should().Match(rooms => rooms.All(r => r.Windows.All(w => w.BorderColor == newColor)));
        }
    }
}
