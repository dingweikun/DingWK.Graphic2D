using System;
using System.Windows;
using System.Windows.Media;

namespace DingWK.Graphic2D.Wpf.Geometric
{
    public sealed class Sector : Circular
    {
        #region fields

        private double _startAngle;
        private double _rangeAngle;
        private double _holeRadius;

        #endregion

        #region constructors

        public Sector(Vector center, Vector radius, double startAngle = 0, double rangeAngle = 90)
            : base(center, radius)
        {
            StartAngle = startAngle;
            RangeAngle = rangeAngle;
        }

        public Sector(double centerX, double centerY, double radiusX, double radiusY, double startAngle, double rangeAngle)
            : this(new Vector(centerX, centerY), new Vector(radiusX, radiusY), startAngle, rangeAngle)
        {
        }

        #endregion

        #region properties

        public double StartAngle
        {
            get => _startAngle;
            set => _startAngle = value % 360;
        }

        public double RangeAngle
        {
            get => _rangeAngle;
            set => _rangeAngle = value % 360;
        }

        public double EndAngle => StartAngle + RangeAngle;

        public double HoleRadius
        {
            get => _holeRadius;
            set => _holeRadius = value < 0 ? 0 : (value > 1 ? 1 : value);
        }

        #endregion

        public override object Clone() => new Sector(Center, Radius, StartAngle, RangeAngle);

        public override void Transform(Matrix matrix)
        {
            throw new NotImplementedException();
        }
    }
}
