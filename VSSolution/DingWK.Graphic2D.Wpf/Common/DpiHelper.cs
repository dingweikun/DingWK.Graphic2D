using System.Windows;
using System.Windows.Media;

namespace DingWK.Graphic2D.Wpf.Common
{
    public static class DpiHelper
    {
        public static double GetDpiFactor(Visual visual) =>
            1 / PresentationSource.FromVisual(visual).CompositionTarget.TransformToDevice.M11;
    }


}



