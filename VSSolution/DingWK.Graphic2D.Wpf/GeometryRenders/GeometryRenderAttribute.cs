using System;

namespace DingWK.Graphic2D.Wpf.GeometryRenders
{
    [AttributeUsage(AttributeTargets.Class)]
    public class GeometryRenderAttribute : Attribute
    {
        private readonly Type _geometryType;

        public Type GeometryType => _geometryType;

        public GeometryRenderAttribute(Type geometryType)
        {
            if (!geometryType.IsSubclassOf(typeof(Geometric.Geometry)))
                throw new ArgumentException($"{nameof(geometryType)} is not Geometry Type");

            _geometryType = geometryType;
        }
    }
}
