using DingWK.Graphic2D.Wpf.Geometric;
using DingWK.Graphic2D.Wpf.GeometryRenders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
