using System.Windows.Media;

namespace DingWK.Graphic2D.Wpf.Controls.Pages
{
    interface IGrid
    {
        int GridSize { get; set; }

        bool GridVisibility { get; set; }

        Color GridColor { get; set; }
    }
}
