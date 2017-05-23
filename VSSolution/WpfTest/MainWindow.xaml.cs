using DingWK.Graphic2D.Wpf.Geometric;
using DingWK.Graphic2D.Wpf.GraphicVisuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            RoundedRect rect = new RoundedRect(10, 10, 200, 100);

            GeometryVisual visual = new GeometryVisual<RoundedRect>();
            visual.Geometry = rect;

            VisualStyle style = new VisualStyle();
            style.Strok = new Pen(Brushes.Red, 4);

            visual.VisualStyle = style;

            //host.Children.Add(visual);


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                $"canvas {cc.Canvas.RenderSize} offset {cc.PageOffset} page {cc.PageSize} scale {cc.ZoomScale}" );
        }
    }
}
