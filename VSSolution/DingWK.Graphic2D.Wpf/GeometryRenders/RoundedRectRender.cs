using DingWK.Graphic2D.Wpf.Geometric;
using System.Windows.Media;
using System.Windows;

namespace DingWK.Graphic2D.Wpf.GeometryRenders
{
    [GeometryRender(typeof(RoundedRect))]
    public sealed class RoundedRectRender : IGeometryRender<RoundedRect>
    {
        public void Draw(DrawingContext dc, RoundedRect geometry, Pen stroke, Brush Fill)
        {
            dc.DrawRoundedRectangle(
                pen: stroke,
                brush: Fill,
                radiusX: geometry.RadiusX,
                radiusY: geometry.RadiusY,
                rectangle: new Rect(geometry.X, geometry.Y, geometry.Width, geometry.Height));
        }
    }
}
