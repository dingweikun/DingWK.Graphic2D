using System.Windows;
using System.Windows.Media;

namespace DingWK.Graphic2D.Wpf.GraphicVisuals
{
    interface IPlacement
    {
        double Angle { get; }
        Point Origin { get; }
        Matrix TransformMatrix { get; }
    }


    public struct Placement : IPlacement
    {
        private double _angle;

        public double Angle
        {
            get => _angle;
            set => _angle = value % 360;
        }

        public Point Origin { get; set; }

        public Matrix TransformMatrix
        {
            get
            {
                Matrix mx = Matrix.Identity;
                mx.Rotate(Angle);
                mx.Translate(Origin.X, Origin.Y);
                return mx;
            }
        }
    }

    
}
