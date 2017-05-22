using System.Windows;
using System.Windows.Media;

namespace DingWK.Graphic2D.Wpf.GraphicVisuals
{
    public class GraphicVisualHost : FrameworkElement
    {
        private readonly VisualCollection _children;


        public GraphicVisualHost()
        {
            _children = new VisualCollection(this);
        }

        public VisualCollection Children => _children;

        protected override int VisualChildrenCount => _children.Count;

        protected override Visual GetVisualChild(int index) => _children[index];



    }
}
