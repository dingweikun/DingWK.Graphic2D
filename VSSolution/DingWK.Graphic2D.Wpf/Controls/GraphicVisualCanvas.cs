using DingWK.Graphic2D.Wpf.Controls.Pages;
using DingWK.Graphic2D.Wpf.Controls.Rulers;
using DingWK.Graphic2D.Wpf.GraphicVisuals;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Media;

namespace DingWK.Graphic2D.Wpf.Controls
{
    /// <summary>
    /// 
    /// </summary>
    [TemplatePart(Name = "PART_Canvas", Type = typeof(Canvas))]
    [TemplatePart(Name = "PART_GridPage", Type = typeof(GridPage))]
    [TemplatePart(Name = "PART_HorRuler", Type = typeof(HorRuler))]
    [TemplatePart(Name = "PART_VerRuler", Type = typeof(VerRuler))]
    [TemplatePart(Name = "PART_HorScrollBar", Type = typeof(ScrollBar))]
    [TemplatePart(Name = "PART_VerScrollBar", Type = typeof(ScrollBar))]
    [TemplatePart(Name = "PART_AdornerDecorator", Type = typeof(AdornerDecorator))]
    [TemplatePart(Name = "PART_GraphicVisualHost", Type = typeof(GraphicVisualHost))]
    public class GraphicVisualCanvas : Control, IPage
    {
        #region constants
        protected const double MaxZoomScale = 100;
        protected const double MinZoomScale = 0.01;
        protected const double Delta = 2;
        #endregion

        static GraphicVisualCanvas()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GraphicVisualCanvas), new FrameworkPropertyMetadata(typeof(GraphicVisualCanvas)));
        }

        public GraphicVisualCanvas()
        {
            Loaded += (sender, e) => SetViewportFitFullPage();
        }


        #region properties

        public Canvas Canvas { get; protected set; }
        public GridPage Page { get; protected set; }
        public AdornerDecorator AdornerDecorator { get; protected set; }
        public GraphicVisualHost GraphicVisualHost { get; protected set; }
        protected ScrollBar HorScrollBar { get; set; }
        protected ScrollBar VerScrollBar { get; set; }

        Size IPage.MaxPageSize => Page.MaxPageSize;
        Size IPage.MinPageSize => Page.MinPageSize;
        Brush IPage.PageBackground
        {
            get => Page.PageBackground;
            set => Page.PageBackground = value;
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

        #region PageOffsetX
        /// <summary>
        /// 
        /// </summary>
        //private double PageOffsetX
        //{
        //    get { return (double)GetValue(PageOffsetXProperty); }
        //    set { SetValue(PageOffsetXProperty, value); }
        //}
        //
        // Dependency property definition
        //
        public static readonly DependencyProperty PageOffsetXProperty =
            DependencyProperty.Register(
                "PageOffsetX",
                typeof(double),
                typeof(GraphicVisualCanvas),
                new FrameworkPropertyMetadata(0.0));
        #endregion

        #region PageOffsetY
        /// <summary>
        /// 
        /// </summary>
        //private double PageOffsetY
        //{
        //    get { return (double)GetValue(PageOffsetYProperty); }
        //    set { SetValue(PageOffsetYProperty, value); }
        //}
        //
        // Dependency property definition
        //
        public static readonly DependencyProperty PageOffsetYProperty =
            DependencyProperty.Register(
                "PageOffsetY",
                typeof(double),
                typeof(GraphicVisualCanvas),
                new FrameworkPropertyMetadata(0.0));
        #endregion
 
        #region PageOffset
        /// <summary>
        /// 
        /// </summary>
        public Vector PageOffset
        {
            get { return (Vector)GetValue(PageOffsetProperty); }
            set { SetValue(PageOffsetProperty, value); }
        }
        //
        // Dependency property definition
        //
        public static readonly DependencyProperty PageOffsetProperty =
            DependencyProperty.Register(
                nameof(PageOffset),
                typeof(Vector),
                typeof(GraphicVisualCanvas),
                new FrameworkPropertyMetadata(new Vector(0, 0), FrameworkPropertyMetadataOptions.AffectsRender)
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
                new FrameworkPropertyMetadata(new Size(400, 200), FrameworkPropertyMetadataOptions.AffectsRender)
                {
                    CoerceValueCallback = (d, baseValue) => GridPage.CoercePageSizeValue((d as GraphicVisualCanvas).Page, baseValue),
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
                new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.AffectsRender)
                {
                    CoerceValueCallback = (d, baseValue) =>
                    {
                        double scale = (double)baseValue;
                        return scale < MinZoomScale ? MinZoomScale : (scale > MaxZoomScale ? MaxZoomScale : scale);
                    },

                    PropertyChangedCallback = (d, e) =>
                    {
                        GraphicVisualCanvas gvc = d as GraphicVisualCanvas;
                        double factor = (double)e.NewValue / (double)e.OldValue;
                        gvc.PageOffset = factor * gvc.PageOffset + (1 - factor) * (Vector)gvc.RenderSize / 2;
                        gvc.UpdateScrollBars();
                    }
                });
        #endregion


        /// <summary>
        /// 
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            Canvas = GetTemplateChild("PART_Canvas") as Canvas;
            Page = GetTemplateChild("PART_GridPage") as GridPage;
            HorScrollBar = GetTemplateChild("PART_HorScrollBar") as ScrollBar;
            VerScrollBar = GetTemplateChild("PART_VerScrollBar") as ScrollBar;
            AdornerDecorator = GetTemplateChild("PART_AdornerDecorator") as AdornerDecorator;
            GraphicVisualHost = GetTemplateChild("PART_GraphicVisualHost") as GraphicVisualHost;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            PageOffset += new Vector(
                x: (sizeInfo.NewSize.Width - sizeInfo.PreviousSize.Width) / 2.0,
                y: (sizeInfo.NewSize.Height - sizeInfo.PreviousSize.Height) / 2.0);
            UpdateScrollBars();
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateScrollBars()
        {
            // set HorScrollBar
            HorScrollBar.Minimum = -Canvas.RenderSize.Width / 2.0;
            HorScrollBar.Maximum = -Canvas.RenderSize.Width / 2.0 + Page.PageSize.Width * ZoomScale;
            HorScrollBar.SmallChange = Canvas.RenderSize.Width / 50;
            HorScrollBar.LargeChange = Canvas.RenderSize.Width;
            HorScrollBar.ViewportSize = Canvas.RenderSize.Width;

            // set VerScrollBar
            VerScrollBar.Minimum = -Canvas.RenderSize.Height / 2.0;
            VerScrollBar.Maximum = -Canvas.RenderSize.Height / 2.0 + Page.PageSize.Height * ZoomScale;
            VerScrollBar.SmallChange = Canvas.RenderSize.Height / 50;
            VerScrollBar.LargeChange = Canvas.RenderSize.Height;
            VerScrollBar.ViewportSize = Canvas.RenderSize.Height;
        }

        /// <summary>
        /// 
        /// </summary>
        protected void SetContentTransform()
        {
            // set grid translate

            Page.RenderTransform = new TranslateTransform(PageOffset.X, PageOffset.Y);

            // set host scale & translate 

            TransformGroup trx = new TransformGroup();
            trx.Children.Add(new ScaleTransform(ZoomScale, ZoomScale));
            trx.Children.Add(new TranslateTransform(PageOffset.X, PageOffset.Y));
            GraphicVisualHost.RenderTransform = trx;
        }

        
        #region Viewport operations

        private void SetViewportFitFullPage()
        {
            if (Canvas.RenderSize.Width * PageSize.Height < Canvas.RenderSize.Height * PageSize.Width)
            {
                ZoomScale = (Canvas.RenderSize.Width - Delta) / PageSize.Width;
                //PageOffset = new Vector(0, (Canvas.RenderSize.Height - ZoomScale * PageSize.Height) / 2);
                PageOffset = new Vector(0, PageOffset.Y);
                PageOffset = new Vector(PageOffset.X, (Canvas.RenderSize.Height - ZoomScale * PageSize.Height) / 2);
            }
            else
            {
                ZoomScale = (Canvas.RenderSize.Height - Delta) / PageSize.Height;
                //PageOffset = new Vector((Canvas.RenderSize.Width - ZoomScale * PageSize.Width) / 2, 0);
                PageOffset = new Vector(PageOffset.X, 0);
                PageOffset = new Vector((Canvas.RenderSize.Width - ZoomScale * PageSize.Width) / 2, PageOffset.Y);
            }
        }

        public void SetCanvasFitPageWidth()
        {
            ZoomScale = (Canvas.RenderSize.Width - Delta) / PageSize.Width;
            PageOffset = new Vector(0, PageOffset.Y);
        }

        public void SetCanvasFitPageHeight()
        {
            ZoomScale = (Canvas.RenderSize.Height - Delta) / PageSize.Height;
            PageOffset = new Vector(PageOffset.X, 0);
        }

        #endregion

    }
}
