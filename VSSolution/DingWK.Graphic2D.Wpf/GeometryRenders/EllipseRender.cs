using DingWK.Graphic2D.Wpf.Geometric;
using System.Windows.Media;
using System.Windows;

namespace DingWK.Graphic2D.Wpf.GeometryRenders
{
    [GeometryRender(typeof(Ellipse))]
    public sealed class EllipseRender : IGeometryRender<Ellipse>
    {
        public void Draw(DrawingContext dc, Ellipse geometry, Pen stroke, Brush Fill)
        {
            dc.DrawEllipse(
                pen: stroke,
                brush: Fill,
                radiusX: geometry.RadiusX,
                radiusY: geometry.RadiusY,
                center: new Point(geometry.CenterX, geometry.CenterY));
        }
    }
}
