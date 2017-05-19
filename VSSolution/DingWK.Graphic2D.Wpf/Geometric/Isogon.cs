using System;
using System.Windows;
using System.Windows.Media;

namespace DingWK.Graphic2D.Wpf.Geometric
{
    public sealed class Isogon : Geometry
    {
        #region constants

        public const int MaxEdgeCount = 12;
        public const int MinEdgeCount = 3;

        #endregion

        #region fields

        private Vector _center;
        private int _edgeCount;
        private double _radius;
        private double _holeRadius;

        #endregion

        #region properties

        public Vector Center
        {
            get => _center;
            set => _center = value;
        }

        public int EdgeCount
        {
            get => _edgeCount;
            set => _edgeCount = value < MinEdgeCount ? MinEdgeCount : (value > MaxEdgeCount ? MaxEdgeCount : value);
        }


        public double Radius
        {
            get => _radius;
            set => _radius = value < 0 ? 0 : value;
        }

        public double HoleRadius
        {
            get => _holeRadius;
            set => _holeRadius = value < 0 ? 0 : (value > 1 ? 1 : value);
        }

        #endregion

        #region constructors

        public Isogon(int edgeCount, Vector center, double radius, double holeRadius = 0)
        {
            Center = center;
            EdgeCount = edgeCount;
            Radius = radius;
            HoleRadius = holeRadius;
        }

        public Isogon(int edgeCount, double centerX, double centerY, double radius, double holeRadius = 0)
            : this(edgeCount, new Vector(centerX, centerY), radius, holeRadius)
        {
        }

        #endregion

        public override object Clone() => new Isogon(EdgeCount, Center, Radius, HoleRadius);

        public override void Transform(Matrix matrix)
        {
            throw new NotImplementedException();
        }
    }
}
