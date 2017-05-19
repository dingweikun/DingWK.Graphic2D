using System;
using System.Windows;

namespace DingWK.Graphic2D.Wpf.GraphicVisuals
{
    public abstract class GeometryVisual : GraphicVisual
    {
        #region Geometry
        /// <summary>
        /// 
        /// </summary>
        public Geometric.Geometry Geometry
        {
            get { return (Geometric.Geometry)GetValue(GeometryProperty); }
            set { SetValue(GeometryProperty, value); }
        }
        //
        // Dependency property definition
        //
        public static readonly DependencyProperty GeometryProperty =
            DependencyProperty.Register(
                nameof(Geometry),
                typeof(Geometric.Geometry),
                typeof(GeometryVisual),
                new FrameworkPropertyMetadata(null, (d, e) => (d as GeometryVisual).UpdateVisualRender()));
        #endregion
    }
    


    public sealed class GeometryVisual<T> : GeometryVisual where T : Geometric.Geometry
    {
        public override void UpdateVisualRender()
        {
            throw new NotImplementedException();
        }
    }

}
