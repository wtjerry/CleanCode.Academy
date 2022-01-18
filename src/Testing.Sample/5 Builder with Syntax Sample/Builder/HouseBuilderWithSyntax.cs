// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HouseBuilderWithSyntax.cs" company="bbv Software Services AG">
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
// <summary>
//   Defines the HouseBuilderWithSyntax type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCode.Testing.Sample.Builder
{
    using System.Drawing;

    using CleanCode.Testing.Sample.SameImplementation;

    public class HouseBuilderWithSyntax : ICreateHouseSyntax, IWithFrontDoorSyntax, IWithWindowSyntax, IBuildHouseSyntax
    {
        private const int LengthInMeters = 30;
        private const int WidthInMeters = 12;
        private const double DefaultDoorHeightInMeters = 2.1d;
        private const double DefaultDoorWidthInMeters = 1.2d;
        private const double DefaultFloorHeightInMeters = 2.4d;
        private const double DefaultRoofSizeInSquareMeters = LengthInMeters * WidthInMeters;

        private readonly House house;

        private Floor newestFloor;
        private Room newestRoom;

        private HouseBuilderWithSyntax()
        {
            this.house = new House(WidthInMeters, LengthInMeters)
            {
                Roof = new Roof { Color = Color.Red, Size = DefaultRoofSizeInSquareMeters },
                FacadeColor = Color.Gray,
                FrontDoor = new FrontDoor
                {
                    Color = Color.Gray,
                    Width = DefaultDoorWidthInMeters,
                    Height = DefaultDoorHeightInMeters
                }
            };
        }

        public static IWithFrontDoorSyntax Create()
        {
            return new HouseBuilderWithSyntax();
        }

        public IWithFrontDoorSyntax CreateHouse()
        {
            return new HouseBuilderWithSyntax();
        }

        public IWithFloorSyntax WithFrontDoorOfColor(Color frontDoorColor)
        {
            this.house.FrontDoor.Color = frontDoorColor;

            return this;
        }

        public IWithRoomSyntax AddFloor()
        {
            int nextFloorLevel = this.house.Floors.Count;

            var newFloor = new Floor(nextFloorLevel, DefaultFloorHeightInMeters);

            this.house.AddFloor(newFloor);

            this.newestFloor = newFloor;

            return this;
        }

        public IWithWindowSyntax AddRoom()
        {
            var newRoom = new Room();

            this.newestFloor.AddRoom(newRoom);

            this.newestRoom = newRoom;

            return this;
        }

        public IWithWindowSyntax WithRoom(Room room)
        {
            this.newestFloor.AddRoom(room);

            return this;
        }

        public IBuildHouseSyntax WithRoomHavingWindowsQuantityOf(int numberOfWindowsInRoom)
        {
            var newRoom = new Room();

            for (int i = 0; i < numberOfWindowsInRoom; i++)
            {
                newRoom.AddWindow(new Window());
            }

            this.newestFloor.AddRoom(newRoom);

            return this;
        }

        public IBuildHouseSyntax AddWindowWithBorderColor(Color borderColor)
        {
            var window = new Window { BorderColor = borderColor };

            this.newestRoom.AddWindow(window);

            return this;
        }

        public IBuildHouseSyntax WithWindow(Window window)
        {
            this.newestRoom.AddWindow(window);

            return this;
        }

        public House Build()
        {
            return this.house;
        }
    }
}