using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace DingWK.Graphic2D.Geometric
{
    public sealed class Polygon : Geometry
    {
        public const int MinVertexCount = 3;

        private List<Vector2> _vertex;
        
        public Polygon(ICollection<Vector2> vertex)
        {
            Vertex = vertex;
        }
        
        public ICollection<Vector2> Vertex
        {
            get => _vertex.ToArray();
            set
            {
                if (_vertex == null)
                    throw new ArgumentNullException();
                if (_vertex.Count < MinVertexCount)
                    throw new ArgumentException();
                _vertex = value.ToList();
            }
        }

        protected override Vector2[] GeometryTransformVectors => Vertex as Vector2[];
                
        public override object Clone() => new Polygon(Vertex);
        
        protected override void SetGeometryTransformVectors(Vector2[] vectors)
        {
            base.SetGeometryTransformVectors(vectors);
            Vertex = vectors;
        }

    }
}
