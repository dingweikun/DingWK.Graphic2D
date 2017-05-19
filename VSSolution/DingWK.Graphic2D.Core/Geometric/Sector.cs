using System.Numerics;

namespace DingWK.Graphic2D.Geometric
{
    public sealed class Sector : CircularGeometry
    {
        #region fields

        private float _startAngle;
        private float _rangeAngle;
        private float _holeRadius;

        #endregion

        #region constructors

        public Sector(Vector2 center, Vector2 radius, float startAngle = 0, float rangeAngle = 90)
            : base(center, radius)
        {
            StartAngle = startAngle;
            RangeAngle = rangeAngle;
        }

        public Sector(float centerX, float centerY, float radiusX, float radiusY, float startAngle, float rangeAngle)
            : this(new Vector2(centerX, centerY), new Vector2(radiusX, radiusY), startAngle, rangeAngle)
        {
        }

        #endregion

        #region properties

        public float StartAngle
        {
            get => _startAngle;
            set => _startAngle = value % 360;
        }

        public float RangeAngle
        {
            get => _rangeAngle;
            set => _rangeAngle = value % 360;
        }

        public float EndAngle => StartAngle + RangeAngle;

        public float HoleRadius
        {
            get => _holeRadius;
            set => _holeRadius = value < 0 ? 0 : (value > 1 ? 1 : value);
        }

        #endregion

        public override object Clone() => new Sector(Center, Radius, StartAngle, RangeAngle);

    }
}
