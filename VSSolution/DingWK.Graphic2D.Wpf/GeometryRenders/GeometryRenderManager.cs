using System;
using System.Collections.Generic;
using System.Reflection;

namespace DingWK.Graphic2D.Wpf.GeometryRenders
{
    public static class GeometryRenderManager
    {
        private static readonly Dictionary<Type, object> RenderDictionary;

        static GeometryRenderManager()
        {
            RenderDictionary = CreateRenderDictionary();
        }

        private static Dictionary<Type, object> CreateRenderDictionary()
        {
            var dict = new Dictionary<Type, object>();
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.IsAbstract == false &&
                    type.GetCustomAttribute(typeof(GeometryRenderAttribute)) is GeometryRenderAttribute attr)
                {
                    dict.Add(attr.GeometryType, Activator.CreateInstance(type));
                }
            }
            return dict;
        }

        public static IGeometryRender<T> GetRender<T>() where T : Geometric.Geometry
            => RenderDictionary[typeof(T)] as IGeometryRender<T>;
    }

}
