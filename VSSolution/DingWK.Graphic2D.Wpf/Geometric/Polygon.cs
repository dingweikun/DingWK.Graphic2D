using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace DingWK.Graphic2D.Wpf.Geometric
{
    public sealed class Polygon : Geometry
    {
        public const int MinVertexCount = 3;

        private List<Vector> _vertex;
        
        public Polygon(ICollection<Vector> vertex)
        {
            Vertex = vertex;
        }
        
        public ICollection<Vector> Vertex
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
           
        public override object Clone() => new Polygon(Vertex);

        public override void Transform(Matrix matrix)
        {
            throw new NotImplementedException();
        }
    }
}
