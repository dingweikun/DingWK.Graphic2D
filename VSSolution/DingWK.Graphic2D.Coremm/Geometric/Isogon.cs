using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DingWK.Graphic2D.Geometric
{
    public sealed class Isogon : CircularGeometry
    {
        #region constants

        public const int MaxEdgeCount = 12;
        public const int MinEdgeCount = 3;

        #endregion

        #region fields

        private int _edgeCount;
        private float _holeRadius;

        #endregion

        #region properties

        public int EdgeCount
        {
            get => _edgeCount;
            set => _edgeCount = value < MinEdgeCount ? MinEdgeCount : (value > MaxEdgeCount ? MaxEdgeCount : value);
        }

        public float HoleRadius
        {
            get => _holeRadius;
            set => _holeRadius = value < 0 ? 0 : (value > 1 ? 1 : value);
        }

        #endregion

        #region constructors

        public Isogon(Vector2 center, Vector2 radius, int edgeCount)
            : base(center, radius)
        {
            EdgeCount = edgeCount;
        }

        public Isogon(float x, float y, float width, float height, int edgeCount)
            : this(new Vector2(x, y), new Vector2(width, height), edgeCount)
        {
        }

        #endregion
        
        public override object Clone() => new Isogon(Center, Radius, EdgeCount);

    }
}
