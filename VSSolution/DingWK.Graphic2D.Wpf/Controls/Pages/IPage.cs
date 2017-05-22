using System.Windows;
using System.Windows.Media;

namespace DingWK.Graphic2D.Wpf.Controls.Pages
{
    public interface IPage
    {
        Size MaxPageSize { get; }

        Size MinPageSize { get; }

        Size PageSize { get; set; }

        Brush PageBackground { get; set; }
    }
}
