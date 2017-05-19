using System.Numerics;

namespace DingWK.Graphic2D.Geometric
{
    public sealed class Ellipse : CircularGeometry
    {
        #region constructors

        public Ellipse(Vector2 center, Vector2 radius)
            : base(center, radius)
        {
        }

        public Ellipse(float centerX, float centerY, float radiusX, float radiusY)
            : this(new Vector2(centerX, centerY), new Vector2(radiusX, radiusY))
        {
        }
        
        #endregion

        #region properties

        public Vector2 Size => Radius * 2;

        public float Width => RadiusX * 2;

        public float Height => RadiusY * 2;

        #endregion

        public override object Clone() => new Ellipse(Center, Radius);

    }
}
