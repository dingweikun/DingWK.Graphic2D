using DingWK.Graphic2D.Wpf.Geometric;
using DingWK.Graphic2D.Wpf.GeometryRenders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConsoleFrameworkTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Isogon i = new Isogon(0, 0, 100, 100, 2);

            Console.WriteLine(i.EdgeCount);

            var ff = GeometryRenderManager.GetRender<Isogon>();

            ff.Draw(null, i, null, null);


            Console.WriteLine(typeof(Isogon).IsSubclassOf(typeof(Geometry)));

            Console.WriteLine(Size.Empty);
            Console.WriteLine(Size.Empty == new Size(0, 0));
            Console.WriteLine(Size.Empty.Height);

            for (int n = 0; n < double.PositiveInfinity; n++)
            {
                Console.WriteLine(n);
            }
        }
    }
}
