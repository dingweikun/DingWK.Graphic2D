using System.Numerics;

namespace DingWK.Graphic2D.Geometric
{
    public sealed class RoundedRect : Geometry
    {
        #region fields

        private Vector2 _location;
        private Vector2 _size;
        private Vector2 _radius;

        #endregion

        #region constructors

        public RoundedRect(Vector2 location, Vector2 size, Vector2 radius = new Vector2())
        {
            Location = location;
            Size = size;
            Radius = radius;
        }

        public RoundedRect(float x, float y, float width, float height)
            : this(new Vector2(x, y), new Vector2(width, height))
        {
        }

        #endregion

        #region properties

        public Vector2 Radius
        {
            get => _radius;
            set
            {
                RadiusX = value.X;
                RadiusY = value.Y;
            }
        }

        public float RadiusX
        {
            get => _radius.X;
            set => _radius.X = value < 0 ? 0 : value;
        }

        public float RadiusY
        {
            get => _radius.Y;
            set => _radius.Y = value < 0 ? 0 : value;
        }

        public Vector2 Location
        {
            get => _location;
            set => _location = value;
        }

        public float X
        {
            get => _location.X;
            set => _location.X = value;
        }

        public float Y
        {
            get => _location.Y;
            set => _location.Y = value;
        }

        public Vector2 Size
        {
            get => _size;
            set
            {
                Width = value.X;
                Height = value.Y;
            }
        }

        public float Width
        {
            get => _size.X;
            set => _size.X = value < 0 ? 0 : value;
        }

        public float Height
        {
            get => _size.Y;
            set => _size.Y = value < 0 ? 0 : value;
        }

        protected override Vector2[] GeometryTransformVectors => new Vector2[] { Location, Size };

        #endregion

        public override object Clone() => new RoundedRect(Location, Size, Radius);

        protected override void SetGeometryTransformVectors(Vector2[] vectors)
        {
            base.SetGeometryTransformVectors(vectors);
            Location = vectors[0];
            Size = vectors[1];
        }

    }
}
