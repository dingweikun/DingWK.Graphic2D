using System;
using System.Numerics;
using DingWK.Graphic2D.Core.Common;

namespace DingWK.Graphic2D.Geometric
{
    /// <summary>
    /// Classes that derive from this abstract base class define geometric shapes.
    /// </summary>
    public abstract class Geometry : ICloneable
    {
        /// <summary>
        /// Gets a vector array that represents the shape information of the Geometry object.
        /// This array is used for doing graphic tranform by multiplied with transform matrix. 
        /// </summary>
        protected abstract Vector2[] GeometryTransformVectors { get; }

        /// <summary>
        /// Creates a new Geometry object that is a copy of the current instance.
        /// </summary>
        public abstract object Clone();

        /// <summary>
        /// Set the geometry instance with a vector array. 
        /// This method is involked by static Transform method for doing geometric transform.
        /// </summary>
        protected virtual void SetGeometryTransformVectors(Vector2[] vectors)
        {
            if (vectors == null)
                throw new ArgumentNullException();
        }

        /// <summary>
        /// A static method for transforming geometry object using specific transform matrix.
        /// </summary>
        public static void Transform<T>(T geometry, Matrix3x2 matrix) where T : Geometry
        {
            if (geometry != null)
            {
                var vecotrs = geometry.GeometryTransformVectors;
                for (int i = 0; i < vecotrs.Length; i++)
                {
                    vecotrs[i] = Vector2.Transform(vecotrs[i], matrix);
                }
                geometry.SetGeometryTransformVectors(vecotrs);
            }
        }

        /// <summary>
        /// Creates a new Geometry object that is a copy of the current instance.
        /// </summary>
        public static T Clone<T>(T geometry) where T : Geometry => geometry?.Clone() as T;

    }


}
