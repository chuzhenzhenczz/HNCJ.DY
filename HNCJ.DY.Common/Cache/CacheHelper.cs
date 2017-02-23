using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HNCJ.DY.Common.Cache
{
    public class CacheHelper
    {
        public static ICacheWriter CacheWriter { get; set; }
        static CacheHelper() {
            IApplicationContext ctx = ContextRegistry.GetContext();
           // ctx.GetObject("CacheHelper");
            CacheHelper.CacheWriter =ctx.GetObject("CacheWriter") as ICacheWriter;
        }
        public static void AddCache(string key, object value, DateTime expDate)
        {
            CacheWriter.AddCache(key, value, expDate);
        }

        public static void AddCache(string key, object value)
        {
            CacheWriter.AddCache(key, value);
        }

        public static object GetCache(string key)
        {
            return CacheWriter.GetCache(key);
        }

        public static T GetCache<T>(string key)
        {
            return (T)CacheWriter.GetCache(key);
        }

        public static void SetCache(string key, object value, DateTime expDate)
        {
            CacheWriter.SetCache(key, value, expDate);
        }
        public static void SetCache(string key, object value)
        {
            CacheWriter.SetCache(key, value );
        }
    }
}
