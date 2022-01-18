// --------------------------------------------------------------------------------------------------------------------
// <copyright file="House.cs" company="bbv Software Services AG">
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

namespace CleanCode.Testing.Sample.Implementation
{
    using System;
    using System.Collections.ObjectModel;
    using System.Drawing;
    using System.Xml.Serialization;

    [Serializable]
    [XmlRoot("house")]
    public class House
    {
        [XmlElement("roof")]
        public Roof Roof { get; set; }

        [XmlElement("door")]
        public FrontDoor FrontDoor { get; set; }

        [XmlArray("windows")]
        [XmlArrayItem("window")]
        public Collection<Window> Windows { get; set; }

        [XmlIgnore]
        public Color FacadeColor
        {
            get { return ColorConverter.FromString(this.FacadeColorAsString); }
            set { this.FacadeColorAsString = ColorConverter.ToString(value); }
        }

        [XmlElement("facadeColor")]
        public string FacadeColorAsString { get; set; }

        [XmlAttribute("height")]
        public double Height { get; set; }

        [XmlAttribute("width")]
        public double Width { get; set; }

        [XmlElement("floors")]
        public int NumberOfFloors { get; set; }
    }
}