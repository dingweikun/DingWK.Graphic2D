using System;
using System.Windows;
using System.Windows.Media;

namespace DingWK.Graphic2D.Wpf.Geometric
{
    /// <summary>
    /// Classes that derive from this abstract base class define geometric shapes.
    /// </summary>
    public abstract class Geometry : ICloneable
    {
        /// <summary>
        /// Creates a new Geometry object that is a copy of the current instance.
        /// </summary>
        public abstract object Clone();
        
        /// <summary>
        /// 
        /// </summary>
        public abstract void Transform(Matrix matrix);

        /// <summary>
        /// A static method for transforming geometry object using specific transform matrix.
        /// </summary>
        public static void Transform<T>(T geometry, Matrix matrix) where T : Geometry => geometry?.Transform(matrix);

        /// <summary>
        /// Creates a new Geometry object that is a copy of the current instance.
        /// </summary>
        public static T Clone<T>(T geometry) where T : Geometry => geometry?.Clone() as T;

    }


}
