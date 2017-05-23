using DingWK.Graphic2D.Wpf.Controls.Pages;
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
    [TemplatePart(Name = "PART_GridPage", Type = typeof(GridPage))]
    [TemplatePart(Name = "PART_HorRuler", Type = typeof(HorRuler))]
    [TemplatePart(Name = "PART_VerRuler", Type = typeof(VerRuler))]
    //[TemplatePart(Name = "PART_HorScrollBar", Type = typeof(ScrollBar))]
    //[TemplatePart(Name = "PART_VerScrollBar", Type = typeof(ScrollBar))]
    [TemplatePart(Name = "PART_AdornerDecorator", Type = typeof(AdornerDecorator))]
    [TemplatePart(Name = "PART_GraphicVisualHost", Type = typeof(GraphicVisualHost))]
    public class GraphicVisualCanvas : Control, IPage
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
        protected GridPage _gridPage = null;
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
        public GridPage Page => _gridPage;
        public AdornerDecorator AdornerDecorator => _adornerDecorator;
        public GraphicVisualHost GraphicVisualHost => _graphicVisualHost;

        Size IPage.MaxPageSize => _gridPage.MaxPageSize;
        Size IPage.MinPageSize => _gridPage.MinPageSize;

        public Brush PageBackground
        {
            get => _gridPage.PageBackground;
            set => _gridPage.PageBackground = value;
        }

        #endregion
                

        #region AccentBrush
        /// <summary>
        /// 
        /// </summary>
        public Brush AccentBrush
        {
            get { return (Brush)GetValue(AccentBrushProperty); }
            set { SetValue(AccentBrushProperty, value); }
        }
        //
        // Dependency property definition
        //
        public static readonly DependencyProperty AccentBrushProperty =
            DependencyProperty.Register(
                nameof(AccentBrush),
                typeof(Brush),
                typeof(GraphicVisualCanvas),
                new FrameworkPropertyMetadata(Brushes.Gray.CloneCurrentValue(), FrameworkPropertyMetadataOptions.AffectsRender));
        #endregion

        
        #region PageOffset
        /// <summary>
        /// 
        /// </summary>
        protected Point PageOffset
        {
            get { return (Point)GetValue(PageOffsetProperty); }
            set { SetValue(PageOffsetProperty, value); }
        }
        //
        // Dependency property definition
        //
        protected static readonly DependencyProperty PageOffsetProperty =
            DependencyProperty.Register(
                nameof(PageOffset),
                typeof(Point),
                typeof(GraphicVisualCanvas),
                new FrameworkPropertyMetadata(new Point(0, 0))
                {
                    PropertyChangedCallback = (d, e) => (d as GraphicVisualCanvas).SetContentTransform()
                });
        #endregion


        #region PageSize
        /// <summary>
        /// 
        /// </summary>
        public Size PageSize
        {
            get { return (Size)GetValue(PageSizeProperty); }
            set { SetValue(PageSizeProperty, value); }
        }
        //
        // Dependency property definition
        //
        public static readonly DependencyProperty PageSizeProperty =
            DependencyProperty.Register(
                nameof(PageSize),
                typeof(Size),
                typeof(GraphicVisualCanvas),
                new FrameworkPropertyMetadata(new Size(400, 200))
                {
                    PropertyChangedCallback = (d, e) => (d as GraphicVisualCanvas).SetViewportFitFullPage()
                });
        #endregion


        #region ZoomScale
        /// <summary>
        /// 
        /// </summary>
        public double ZoomScale
        {
            get { return (double)GetValue(ZoomScaleProperty); }
            set { SetValue(ZoomScaleProperty, value); }
        }
        //
        // Dependency property definition
        //
        public static readonly DependencyProperty ZoomScaleProperty =
            DependencyProperty.Register(
                nameof(ZoomScale),
                typeof(double),
                typeof(GraphicVisualCanvas),
                new FrameworkPropertyMetadata(1.0)
                {

                });
        #endregion





        /// <summary>
        /// 
        /// </summary>
        private void UpdateScrollBars()
        {
            if (Canvas == null) return;

            if (_horScrollBar != null)
            {
                _horScrollBar.Minimum = -Canvas.RenderSize.Width / 2;
                _horScrollBar.Maximum = -Canvas.RenderSize.Width / 2 + Page.PageSize.Width * ZoomScale;
                _horScrollBar.SmallChange = Canvas.RenderSize.Width / 50;
                _horScrollBar.LargeChange = Canvas.RenderSize.Width;
                _horScrollBar.ViewportSize = Canvas.RenderSize.Width;
            }

            if (_verScrollBar != null)
            {
                _verScrollBar.Minimum = -Canvas.RenderSize.Height / 2;
                _verScrollBar.Maximum = -Canvas.RenderSize.Height / 2 + Page.PageSize.Height * ZoomScale;
                _verScrollBar.SmallChange = Canvas.RenderSize.Height / 50;
                _verScrollBar.LargeChange = Canvas.RenderSize.Height;
                _verScrollBar.ViewportSize = Canvas.RenderSize.Height;
            }
        }



        /// <summary>
        /// 
        /// </summary>
        protected void SetContentTransform()
        {
            // set grid translate

            _gridPage.RenderTransform = new TranslateTransform(PageOffset.X, PageOffset.Y);

            // set host scale & translate 

            TransformGroup trx = new TransformGroup();
            trx.Children.Add(new ScaleTransform(ZoomScale, ZoomScale));
            trx.Children.Add(new TranslateTransform(PageOffset.X, PageOffset.Y));
            GraphicVisualHost.RenderTransform = trx;
        }




        private void SetViewportFitFullPage()
        {
            
            throw new NotImplementedException();
        }
















        /// <summary>
        /// 
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _canvas = GetTemplateChild("PART_Canvas") as Canvas;
            _gridPage = GetTemplateChild("PART_GridPage") as GridPage;
            _horScrollBar = GetTemplateChild("PART_HorScrollBar") as ScrollBar;
            _verScrollBar = GetTemplateChild("PART_VerScrollBar") as ScrollBar;
            _adornerDecorator = GetTemplateChild("PART_AdornerDecorator") as AdornerDecorator;
            _graphicVisualHost = GetTemplateChild("PART_GraphicVisualHost") as GraphicVisualHost;

        }



    }
}
