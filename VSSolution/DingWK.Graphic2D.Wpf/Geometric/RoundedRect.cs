using System;
using System.Windows;
using System.Windows.Media;

namespace DingWK.Graphic2D.Wpf.Geometric
{
    public sealed class RoundedRect : Geometry
    {
        #region fields

        private Vector _location;
        private Vector _size;
        private Vector _radius;

        #endregion

        #region constructors

        public RoundedRect(Vector location, Vector size, Vector radius = new Vector())
        {
            Location = location;
            Size = size;
            Radius = radius;
        }

        public RoundedRect(double x, double y, double width, double height)
            : this(new Vector(x, y), new Vector(width, height))
        {
        }

        #endregion

        #region properties

        public Vector Radius
        {
            get => _radius;
            set
            {
                RadiusX = value.X;
                RadiusY = value.Y;
            }
        }

        public double RadiusX
        {
            get => _radius.X;
            set => _radius.X = value < 0 ? 0 : value;
        }

        public double RadiusY
        {
            get => _radius.Y;
            set => _radius.Y = value < 0 ? 0 : value;
        }

        public Vector Location
        {
            get => _location;
            set => _location = value;
        }

        public double X
        {
            get => _location.X;
            set => _location.X = value;
        }

        public double Y
        {
            get => _location.Y;
            set => _location.Y = value;
        }

        public Vector Size
        {
            get => _size;
            set
            {
                Width = value.X;
                Height = value.Y;
            }
        }

        public double Width
        {
            get => _size.X;
            set => _size.X = value < 0 ? 0 : value;
        }

        public double Height
        {
            get => _size.Y;
            set => _size.Y = value < 0 ? 0 : value;
        }

        #endregion

        public override object Clone() => new RoundedRect(Location, Size, Radius);

        public override void Transform(Matrix matrix)
        {
            throw new NotImplementedException();
        }

    }
}
