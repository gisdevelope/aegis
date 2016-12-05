﻿// <copyright file="StoredLine.cs" company="Eötvös Loránd University (ELTE)">
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

namespace ELTE.AEGIS.Storage.Geometries
{
    using System;
    using System.Collections.Generic;
    using ELTE.AEGIS.Resources;

    /// <summary>
    /// Represents a line geometry located in a store.
    /// </summary>
    public class StoredLine : StoredLineString, ILine
    {
        /// <summary>
        /// The name of the line. This field is constant.
        /// </summary>
        private const String LineName = "LINE";

        /// <summary>
        /// Initializes a new instance of the <see cref="StoredLine" /> class.
        /// </summary>
        /// <param name="precisionModel">The precision model.</param>
        /// <param name="driver">The geometry driver.</param>
        /// <param name="identifier">The feature identifier.</param>
        /// <param name="indexes">The indexes of the geometry within the feature.</param>
        /// <exception cref="System.ArgumentNullException">
        /// The driver is null.
        /// or
        /// The identifier is null.
        /// </exception>
        public StoredLine(PrecisionModel precisionModel, IGeometryDriver driver, String identifier, IEnumerable<Int32> indexes)
            : base(precisionModel, driver, identifier, indexes)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoredLine" /> class.
        /// </summary>
        /// <param name="factory">The factory.</param>
        /// <param name="identifier">The feature identifier.</param>
        /// <param name="indexes">The indexes of the geometry within the feature.</param>
        /// <exception cref="System.ArgumentNullException">
        /// The factory is null.
        /// or
        /// The identifier is null.
        /// </exception>
        public StoredLine(StoredGeometryFactory factory, String identifier, IEnumerable<Int32> indexes)
            : base(factory, identifier, indexes)
        {
        }

        /// <summary>
        /// Gets a value indicating whether the current geometry is simple.
        /// </summary>
        /// <value><c>true</c>, as a line is always considered to be simple.</value>
        public override Boolean IsSimple { get { return true; } }

        /// <summary>
        /// Gets the length of the line.
        /// </summary>
        /// <value>The length of the line.</value>
        public override Double Length { get { return Coordinate.Distance(this.StartCoordinate, this.EndCoordinate); } }

        /// <summary>
        /// Adds a coordinate to the end of the line.
        /// </summary>
        /// <param name="coordinate">The coordinate.</param>
        /// <exception cref="System.NotSupportedException">Extension of lines is not supported.</exception>
        public override void Add(Coordinate coordinate)
        {
            throw new NotSupportedException(CoreMessages.LineExtensionNotSupported);
        }

        /// <summary>
        /// Inserts a coordinate into the line at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which the coordinate should be inserted.</param>
        /// <param name="coordinate">The coordinate.</param>
        /// <exception cref="System.NotSupportedException">Extension of lines is not supported.</exception>
        public override void Insert(Int32 index, Coordinate coordinate)
        {
            throw new NotSupportedException(CoreMessages.LineExtensionNotSupported);
        }

        /// <summary>
        /// Removes the first occurrence of the specified coordinate from the line.
        /// </summary>
        /// <param name="coordinate">The coordinate.</param>
        /// <returns><c>true</c> if the coordinate was removed; otherwise, <c>false</c>.</returns>
        /// <exception cref="System.NotSupportedException">Reduction of lines is not supported.</exception>
        public override Boolean Remove(Coordinate coordinate)
        {
            throw new NotSupportedException(CoreMessages.LineReductionNotSupported);
        }

        /// <summary>
        /// Removes the coordinate at the specified index from the line.
        /// </summary>
        /// <param name="index">The zero-based index of the coordinate to remove.</param>
        /// <exception cref="System.NotSupportedException">Reduction of lines is not supported.</exception>
        public override void RemoveAt(Int32 index)
        {
            throw new NotSupportedException(CoreMessages.LineReductionNotSupported);
        }

        /// <summary>
        /// Returns the <see cref="System.String" /> equivalent of the instance.
        /// </summary>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A <see cref="System.String" /> containing the coordinates in all dimensions.</returns>
        public override String ToString(IFormatProvider provider)
        {
            return this.ToString(provider, LineName);
        }
    }
}
