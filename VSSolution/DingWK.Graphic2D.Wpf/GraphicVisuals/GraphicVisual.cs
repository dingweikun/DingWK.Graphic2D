using System.Windows;
using System.Windows.Media;

namespace DingWK.Graphic2D.Wpf.GraphicVisuals
{
    public abstract class GraphicVisual : DrawingVisual, IPlacement, IVisualStyle
    {
        public double Angle => Placement.Angle;

        public Point Origin => Placement.Origin;

        public Matrix TransformMatrix => Placement.TransformMatrix;

        public Pen Strok => VisualStyle.Strok;

        public Brush Fill => VisualStyle.Fill;
        
        #region Placement
        /// <summary>
        /// 
        /// </summary>
        public Placement Placement
        {
            get => (Placement)GetValue(PlacementProperty);
            set => SetValue(PlacementProperty, value);
        }
        //
        // Dependency property definition
        //
        protected static readonly DependencyProperty PlacementProperty =
            DependencyProperty.Register(
                nameof(Placement),
                typeof(Placement),
                typeof(GraphicVisual),
                new FrameworkPropertyMetadata(new Placement(), (d, e) => (d as GraphicVisual)?.UpdateVisualTransform()));
        #endregion

        #region VisualStyle
        /// <summary>
        /// 
        /// </summary>
        public VisualStyle VisualStyle
        {
            get { return (VisualStyle)GetValue(VisualStyleProperty); }
            set { SetValue(VisualStyleProperty, value); }
        }
        //
        // Dependency property definition
        //
        protected static readonly DependencyProperty VisualStyleProperty =
            DependencyProperty.Register(
                nameof(VisualStyle),
                typeof(VisualStyle),
                typeof(GraphicVisual),
                new FrameworkPropertyMetadata(new VisualStyle(), (d, e) => (d as GraphicVisual)?.UpdateVisualRender()));
        #endregion

        public void UpdateVisual(GraphicVisual visual)
        {
            UpdateVisualRender();
            UpdateVisualTransform();
        }

        public void UpdateVisualTransform() => Transform = new MatrixTransform(TransformMatrix);

        public abstract void UpdateVisualRender();

    }

}
