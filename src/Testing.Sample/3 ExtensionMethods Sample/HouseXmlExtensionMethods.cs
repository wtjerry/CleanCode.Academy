// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HouseXmlExtensionMethods.cs" company="bbv Software Services AG">
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
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Xml.Linq;

    public static class HouseXmlExtensionMethods
    {
        public const string RootElementName = "house";
        public const string RoofElementName = "roof";
        public const string FrontDoorElementName = "door";
        public const string FacadeColorElementName = "facadeColor";
        public const string WindowElementName = "window";
        public const string WindowsElementName = "windows";

        public const string ColorAttributeName = "color";

        public static XElement RoofElement(this XDocument document)
        {
            return document.Element(RootElementName).Element(RoofElementName);
        }

        public static XElement FrontDoorElement(this XDocument document)
        {
            return document.Element(RootElementName).Element(FrontDoorElementName);
        }

        public static Color FacadeColorElementValue(this XDocument document)
        {
            string value = document.Element(RootElementName).Element(FacadeColorElementName).Value;

            return value.ToColor().AsNamedColorIfPossible();
        }

        public static ICollection<XElement> WindowElements(this XDocument document)
        {
            return document.Element(RootElementName).Element(WindowsElementName).Elements(WindowElementName).ToList();
        }

        public static Color ColorAttributeValue(this XElement element)
        {
            string value = element.Attribute(ColorAttributeName).Value;
            
            return value.ToColor().AsNamedColorIfPossible();
        }

        private static Color ToColor(this string colorAsString)
        {
            return ColorTranslator.FromHtml(colorAsString);
        }

        private static Color AsNamedColorIfPossible(this Color color)
        {
            int colorArgbValue = color.ToArgb();

            foreach (string knownColorNames in Enum.GetNames(typeof(KnownColor)))
            {
                Color knownColorName = Color.FromName(knownColorNames);

                if (knownColorName.ToArgb() == colorArgbValue)
                {
                    return knownColorName;
                }
            }

            return color;
        }
    }
}