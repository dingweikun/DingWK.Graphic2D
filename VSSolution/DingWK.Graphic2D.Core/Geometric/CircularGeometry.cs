using System.Numerics;

namespace DingWK.Graphic2D.Geometric
{
    public abstract class CircularGeometry : Geometry
    {
        private Vector2 _center;
        private Vector2 _radius;


        protected CircularGeometry(Vector2 center, Vector2 radius)
        {
            Center = center;
            Radius = radius;
        }


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

        public Vector2 Center
        {
            get => _center;
            set => _center = value;
        }

        public float CenterX
        {
            get => _center.X;
            set => _center.X = value;
        }

        public float CenterY
        {
            get => _center.Y;
            set => _center.Y = value;
        }

        protected override Vector2[] GeometryTransformVectors => new Vector2[] { Center, Radius };

        protected override void SetGeometryTransformVectors(Vector2[] vectors)
        {
            base.SetGeometryTransformVectors(vectors);
            Center = vectors[0];
            Radius = vectors[1];
        }


    }
}
