// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HousePainter.cs" company="bbv Software Services AG">
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

namespace CleanCode.Testing.Sample.SampleImplementation
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public class HousePainter
    {
        private readonly House house;

        public HousePainter(House house)
        {
            this.house = house;
        }

        public void ChangeColorOfRoof(Color color)
        {
            this.house.Roof.Color = color;
        }

        public void ChangeColorOfFacade(Color color)
        {
            this.house.FacadeColor = color;
        }

        public void ChangeColorOfFrontDoor(Color color)
        {
            this.house.FrontDoor.Color = color;
        }

        public void ChangeBorderColorOfAllWindows(Color color)
        {
            var windowQuery = from floor in this.house.Floors
                              from room in floor.Rooms
                              from window in room.Windows
                              select window;

            List<Window> allWinodowsOfTheHouse = windowQuery.ToList();

            foreach (Window window in allWinodowsOfTheHouse)
            {
                window.BorderColor = color;
            }
        }
    }
}