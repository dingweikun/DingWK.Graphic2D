using System.Windows.Media;

namespace DingWK.Graphic2D.Wpf.GeometryRenders
{
    public interface IGeometryRender<T> where T : Geometric.Geometry
    {
        void Draw(DrawingContext dc, T geometry, Pen stroke, Brush fill);
    }
}
