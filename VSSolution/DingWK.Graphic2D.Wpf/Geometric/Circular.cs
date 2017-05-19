using System.Windows;

namespace DingWK.Graphic2D.Wpf.Geometric
{
    public abstract class Circular : Geometry
    {
        private Vector _center;
        private Vector _radius;


        protected Circular(Vector center, Vector radius)
        {
            Center = center;
            Radius = radius;
        }


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

        public Vector Center
        {
            get => _center;
            set => _center = value;
        }

        public double CenterX
        {
            get => _center.X;
            set => _center.X = value;
        }

        public double CenterY
        {
            get => _center.Y;
            set => _center.Y = value;
        }

    }
}
