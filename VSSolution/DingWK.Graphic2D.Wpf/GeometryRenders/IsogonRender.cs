using DingWK.Graphic2D.Wpf.Geometric;
using System.Windows.Media;
using System;

namespace DingWK.Graphic2D.Wpf.GeometryRenders
{
    [GeometryRender(typeof(Isogon))]
    public sealed class IsogonRender : IGeometryRender<Isogon>
    {
        public void Draw(DrawingContext dc, Isogon geometry, Pen stroke, Brush Fill)
        {
            Console.WriteLine("Drawing a Isogon");
        }
    }
}
