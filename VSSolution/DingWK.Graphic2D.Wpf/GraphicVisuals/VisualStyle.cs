using System.Windows.Media;

namespace DingWK.Graphic2D.Wpf.GraphicVisuals
{

    interface IVisualStyle
    {
        Pen Strok { get; }
        Brush Fill { get; }
    }


    public struct VisualStyle : IVisualStyle
    {
        public Pen Strok { get; set; }
        public Brush Fill { get; set; }
    }

}
