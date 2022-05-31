using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryLibrary
{
    /// <summary>
    /// Interface for different types of surfaces.
    /// </summary>
    public interface ISurface
    {
        /// <summary>
        /// The area of the surface.
        /// </summary>
        double Area { get; }
    }
}
