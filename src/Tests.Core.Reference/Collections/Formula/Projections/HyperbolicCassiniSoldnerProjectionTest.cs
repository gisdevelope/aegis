﻿// <copyright file="HyperbolicCassiniSoldnerProjectionTest.cs" company="Eötvös Loránd University (ELTE)">
//     Copyright 2016 Roberto Giachetta. Licensed under the
//     Educational Community License, Version 2.0 (the "License"); you may
//     not use this file except in compliance with the License. You may
//     obtain a copy of the License at
//     http://opensource.org/licenses/ECL-2.0
//
//     Unless required by applicable law or agreed to in writing,
//     software distributed under the License is distributed on an "AS IS"
//     BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
//     or implied. See the License for the specific language governing
//     permissions and limitations under the License.
// </copyright>

namespace ELTE.AEGIS.Tests.Reference.Collections.Formula
{
    using System;
    using System.Collections.Generic;
    using ELTE.AEGIS.Reference;
    using ELTE.AEGIS.Reference.Collections.Formula;
    using NUnit.Framework;
    using Shouldly;

    /// <summary>
    /// Test fixture for the <see cref="HyperbolicCassiniSoldnerProjection" /> class.
    /// </summary>
    [TestFixture]
    public class HyperbolicCassiniSoldnerProjectionTest
    {
        /// <summary>
        /// The projection.
        /// </summary>
        private HyperbolicCassiniSoldnerProjection projection;

        /// <summary>
        /// Test setup.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            Dictionary<CoordinateOperationParameter, Object> parameters = new Dictionary<CoordinateOperationParameter, Object>();

            parameters = new Dictionary<CoordinateOperationParameter, Object>();
            parameters = new Dictionary<CoordinateOperationParameter, Object>();
            parameters.Add(CoordinateOperationParameters.LatitudeOfNaturalOrigin, Angle.FromDegree(-16, 15, 00));
            parameters.Add(CoordinateOperationParameters.LongitudeOfNaturalOrigin, Angle.FromDegree(179, 20, 00));
            parameters.Add(CoordinateOperationParameters.FalseEasting, Length.Convert(Length.FromClarkesChain(12513.318), UnitsOfMeasurement.ClarkesFoot));
            parameters.Add(CoordinateOperationParameters.FalseNorthing, Length.Convert(Length.FromClarkesChain(16628.885), UnitsOfMeasurement.ClarkesFoot));

            Ellipsoid ellipsoid = Ellipsoid.FromSemiMinorAxis("EPSG::7034", "Clarke 1880", Length.FromClarkesFoot(20926202), Length.FromClarkesFoot(20854895));
            AreaOfUse areaOfUse = TestUtilities.ReferenceCollection.AreasOfUse["EPSG::1262"];

            this.projection = new HyperbolicCassiniSoldnerProjection("EPSG::9833", "Vanua Levu Grid", parameters, ellipsoid, areaOfUse);
        }

        /// <summary>
        /// Tests the forward computation.
        /// </summary>
        [Test]
        public void HyperbolicCassiniSoldnerProjectionForwardTest()
        {
            GeoCoordinate coordinate = new GeoCoordinate(Angle.FromDegree(-16, 50, 29.2435), Angle.FromDegree(179, 59, 39.6115));
            Coordinate expected = new Coordinate(Length.Convert(Length.FromClarkesChain(16015.2890), UnitsOfMeasurement.ClarkesFoot).Value,
                                                 Length.Convert(Length.FromClarkesChain(13369.6601), UnitsOfMeasurement.ClarkesFoot).Value);
            Coordinate transformed = this.projection.Forward(coordinate);

            transformed.X.ShouldBe(expected.X, 0.01);
            transformed.Y.ShouldBe(expected.Y, 0.01);
        }

        /// <summary>
        /// Tests the reverse computation.
        /// </summary>
        [Test]
        public void HyperbolicCassiniSoldnerProjectionReverseTest()
        {
            GeoCoordinate expected = new GeoCoordinate(Angle.FromDegree(-16, 50, 29.2435), Angle.FromDegree(179, 59, 39.6115));
            GeoCoordinate transformed = this.projection.Reverse(this.projection.Forward(expected));

            transformed.Latitude.BaseValue.ShouldBe(expected.Latitude.BaseValue, 0.00000001);
            transformed.Longitude.BaseValue.ShouldBe(expected.Longitude.BaseValue, 0.00000001);
        }
    }
}
