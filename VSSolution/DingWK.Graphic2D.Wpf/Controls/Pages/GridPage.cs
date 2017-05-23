using DingWK.Graphic2D.Wpf.Common;
using System.Windows;
using System.Windows.Media;
using System;

namespace DingWK.Graphic2D.Wpf.Controls.Pages
{
    public class GridPage : FrameworkElement, IGrid, IPage
    {
        protected const int GridSizeInterval = 5;

        public Size MinPageSize => new Size(10, 10);
        public Size MaxPageSize => new Size(1e6, 1e6);


        #region Scale
        /// <summary>
        /// 
        /// </summary>
        public double Scale
        {
            get { return (double)GetValue(ScaleProperty); }
            set { SetValue(ScaleProperty, value); }
        }
        //
        // Dependency property definition
        //
        public static readonly DependencyProperty ScaleProperty =
            DependencyProperty.Register(
                nameof(Scale),
                typeof(double),
                typeof(GridPage),
                new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.AffectsRender));
        #endregion

        #region GridSize
        /// <summary>
        /// 
        /// </summary>
        public int GridSize
        {
            get { return (int)GetValue(GridSizeProperty); }
            set { SetValue(GridSizeProperty, value); }
        }
        //
        // Dependency property definition
        //
        public static readonly DependencyProperty GridSizeProperty =
            DependencyProperty.Register(
                nameof(GridSize),
                typeof(int),
                typeof(GridPage),
                new FrameworkPropertyMetadata(10, FrameworkPropertyMetadataOptions.AffectsRender));
        #endregion
        
        #region GridVisibility
        /// <summary>
        /// 
        /// </summary>
        public bool GridVisibility
        {
            get { return (bool)GetValue(GridVisibilityProperty); }
            set { SetValue(GridVisibilityProperty, value); }
        }
        //
        // Dependency property definition
        //
        public static readonly DependencyProperty GridVisibilityProperty =
            DependencyProperty.Register(
                nameof(GridVisibility),
                typeof(bool),
                typeof(GridPage),
                new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsRender));
        #endregion

        #region GridBrush
        /// <summary>
        /// 
        /// </summary>
        public Brush GridBrush
        {
            get { return (Brush)GetValue(GridBrushProperty); }
            set { SetValue(GridBrushProperty, value); }
        }
        //
        // Dependency property definition
        //
        public static readonly DependencyProperty GridBrushProperty =
            DependencyProperty.Register(
                nameof(GridBrush),
                typeof(Brush),
                typeof(GridPage),
                new FrameworkPropertyMetadata(Brushes.Gray.CloneCurrentValue(), FrameworkPropertyMetadataOptions.AffectsRender));
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
                typeof(GridPage),
                new FrameworkPropertyMetadata(new Size(400, 300), FrameworkPropertyMetadataOptions.AffectsRender)
                {
                    CoerceValueCallback = CoercePageSizeValue
                });
        //
        // CoerceValueCallback
        //
        public static object CoercePageSizeValue(DependencyObject d, object baseValue)
        {
            Size size = (Size)baseValue;
            IPage page = (IPage)d;
            size.Width = size.Width < page.MinPageSize.Width ? page.MinPageSize.Width : size.Width;
            size.Width = size.Width > page.MaxPageSize.Width ? page.MaxPageSize.Width : size.Width;
            size.Height = size.Height < page.MinPageSize.Height ? page.MinPageSize.Height : size.Height;
            size.Height = size.Height > page.MaxPageSize.Height ? page.MaxPageSize.Height : size.Height;
            return size;
        }
        #endregion

        #region PageBackground
        /// <summary>
        /// 
        /// </summary>
        public Brush PageBackground
        {
            get { return (Brush)GetValue(PageBackgroundProperty); }
            set { SetValue(PageBackgroundProperty, value); }
        }

        //
        // Dependency property definition
        //
        public static readonly DependencyProperty PageBackgroundProperty =
            DependencyProperty.Register(
                nameof(PageBackground),
                typeof(Brush),
                typeof(GridPage),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
        #endregion


        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            double dpiFactor = DpiHelper.GetDpiFactor(this);
            double delt = dpiFactor / 2;

            double xlen = PageSize.Width * Scale;
            double ylen = PageSize.Height * Scale;

            Pen majorPen = new Pen(GridBrush, 1 * dpiFactor);
            Brush brush = GridBrush.CloneCurrentValue();
            brush.Opacity = 0.4;
            Pen minorPen = new Pen(brush, 1 * dpiFactor);

            if (majorPen.CanFreeze) majorPen.Freeze();
            if (minorPen.CanFreeze) minorPen.Freeze();

            GuidelineSet guidelineSet = new GuidelineSet();
            guidelineSet.GuidelinesX.Add(0 - delt);
            guidelineSet.GuidelinesX.Add(xlen - delt);
            guidelineSet.GuidelinesY.Add(0 - delt);
            guidelineSet.GuidelinesY.Add(ylen - delt);

            drawingContext.PushGuidelineSet(guidelineSet);
            drawingContext.DrawRectangle(null, minorPen, new Rect(0, 0, xlen, ylen));
            drawingContext.Pop();

            LineGeometry lgx = new LineGeometry(new Point(0, 0), new Point(0, ylen));
            LineGeometry lgy = new LineGeometry(new Point(0, 0), new Point(xlen, 0));
            if (lgx.CanFreeze) lgx.Freeze();
            if (lgy.CanFreeze) lgy.Freeze();

            GuidelineSet guidelines = new GuidelineSet();
            guidelines.GuidelinesX.Add(-delt);
            guidelines.GuidelinesX.Add(xlen - delt);
            guidelines.GuidelinesY.Add(-delt);
            guidelines.GuidelinesY.Add(ylen - delt);

            drawingContext.PushGuidelineSet(guidelines);
            drawingContext.DrawRectangle(PageBackground, majorPen, new Rect(0, 0, xlen, ylen));
            drawingContext.Pop();

            if (!GridVisibility) return;

            for (double x = 0; x <= PageSize.Width; x += GridSize)
            {
                GuidelineSet gridGuidelines = new GuidelineSet();
                gridGuidelines.GuidelinesX.Add(x * Scale - delt);

                drawingContext.PushGuidelineSet(gridGuidelines);
                drawingContext.PushTransform(new TranslateTransform(x * Scale, 0));
                drawingContext.DrawGeometry(null, (x / GridSize) % GridSizeInterval == 0 ? majorPen : minorPen, lgx);
                drawingContext.Pop();
                drawingContext.Pop();
            }

            for (double y = 0; y <= PageSize.Height; y += GridSize)
            {
                GuidelineSet gridGuidelines = new GuidelineSet();
                gridGuidelines.GuidelinesY.Add(y * Scale - delt);

                drawingContext.PushGuidelineSet(gridGuidelines);
                drawingContext.PushTransform(new TranslateTransform(0, y * Scale));
                drawingContext.DrawGeometry(null, (y / GridSize) % GridSizeInterval == 0 ? majorPen : minorPen, lgy);
                drawingContext.Pop();
                drawingContext.Pop();
            }

        }

    }
}


