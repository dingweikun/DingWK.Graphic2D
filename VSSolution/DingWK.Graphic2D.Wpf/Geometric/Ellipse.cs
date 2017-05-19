using System;
using System.Windows;
using System.Windows.Media;

namespace DingWK.Graphic2D.Wpf.Geometric
{
    public sealed class Ellipse : Circular
    {
        #region constructors

        public Ellipse(Vector center, Vector radius)
            : base(center, radius)
        {
        }

        public Ellipse(double centerX, double centerY, double radiusX, double radiusY)
            : this(new Vector(centerX, centerY), new Vector(radiusX, radiusY))
        {
        }
        
        #endregion

        #region properties

        public Vector Size => Radius * 2;

        public double Width => RadiusX * 2;

        public double Height => RadiusY * 2;

        #endregion

        public override object Clone() => new Ellipse(Center, Radius);

        public override void Transform(Matrix matrix)
        {
            throw new NotImplementedException();
        }
    }
}
