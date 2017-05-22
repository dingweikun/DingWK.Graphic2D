using DingWK.Graphic2D.Wpf.Controls.Rulers;
using DingWK.Graphic2D.Wpf.GraphicVisuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DingWK.Graphic2D.Wpf.Controls
{
    /// <summary>
    /// 
    /// </summary>
    [TemplatePart(Name = "PART_Canvas", Type = typeof(Canvas))]
    //[TemplatePart(Name = "PART_PageGrid", Type = typeof(PageGrid))]
    [TemplatePart(Name = "PART_HorRuler", Type = typeof(HorRuler))]
    [TemplatePart(Name = "PART_VerRuler", Type = typeof(VerRuler))]
    //[TemplatePart(Name = "PART_HorScrollBar", Type = typeof(ScrollBar))]
    //[TemplatePart(Name = "PART_VerScrollBar", Type = typeof(ScrollBar))]
    [TemplatePart(Name = "PART_AdornerDecorator", Type = typeof(AdornerDecorator))]
    [TemplatePart(Name = "PART_GraphicVisualHost", Type = typeof(GraphicVisualHost))]
    public class GraphicVisualCanvas : Control
    {

        #region constants
        protected const double MaxPageScale = 100;
        protected const double MinPageScale = 0.01;
        protected const double MaxPageSize = 10000;
        protected const double MinPageSize = 100;
        protected const double Delta = 2;
        #endregion


        #region fields
        protected Canvas _canvas = null;
        //protected PageGrid _pageGrid = null;
        protected ScrollBar _horScrollBar = null;
        protected ScrollBar _verScrollBar = null;
        protected AdornerDecorator _adornerDecorator = null;
        protected GraphicVisualHost _graphicVisualHost = null;
        #endregion


        static GraphicVisualCanvas()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GraphicVisualCanvas), new FrameworkPropertyMetadata(typeof(GraphicVisualCanvas)));
        }


        #region properties
        public Canvas Canvas => _canvas;
        //public PageGrid PageGrid => _pageGrid;
        public AdornerDecorator AdornerDecorator => _adornerDecorator;
        public GraphicVisualHost GraphicVisualHost => _graphicVisualHost;
        #endregion











        /// <summary>
        /// 
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _canvas = GetTemplateChild("PART_Canvas") as Canvas;
            //_pageGrid = GetTemplateChild("PART_PageGrid") as PageGrid;
            _horScrollBar = GetTemplateChild("PART_HorScrollBar") as ScrollBar;
            _verScrollBar = GetTemplateChild("PART_VerScrollBar") as ScrollBar;
            _adornerDecorator = GetTemplateChild("PART_AdornerDecorator") as AdornerDecorator;
            _graphicVisualHost = GetTemplateChild("PART_GraphicVisualHost") as GraphicVisualHost;

        }








    }
}
