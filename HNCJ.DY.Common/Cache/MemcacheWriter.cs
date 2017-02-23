using Memcached.ClientLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HNCJ.DY.Common.Cache
{
    public class MemcacheWriter:ICacheWriter
    {
        private MemcachedClient memcachedClient;
        public MemcacheWriter()
        {
            //string[] servers = { "192.168.1.100:11211", "192.168.1.118:11211" };
            string strmemcache=System.Configuration.ConfigurationManager.AppSettings["MemcacheServerList"];
            string[] servers = strmemcache.Split(',');
            SockIOPool pool = SockIOPool.GetInstance();
            pool.SetServers(servers);
            pool.InitConnections = 3;
            pool.MinConnections = 3;
            pool.MaxConnections = 5;
            pool.SocketConnectTimeout = 1000;
            pool.SocketTimeout = 3000;
            pool.MaintenanceSleep=30;
            pool.Failover = true;
            pool.Nagle = false;
            pool.Initialize();
            MemcachedClient mc = new Memcached.ClientLibrary.MemcachedClient();
            mc.EnableCompression = false;
            memcachedClient = mc;
        }
        public void AddCache(string key, object value, DateTime expDate)
        {
            memcachedClient.Add(key, value, expDate);
        }

        public void AddCache(string key, object value)
        {
            memcachedClient.Add(key, value);
        }

        public object GetCache(string key)
        {
            return memcachedClient.Get(key);
        }

        public T GetCache<T>(string key)
        {
            return (T)memcachedClient.Get(key);
        }


        public void SetCache(string key, object value, DateTime expDate)
        {
            memcachedClient.Set(key, value, expDate);
        }

        public void SetCache(string key, object value)
        {
            memcachedClient.Set(key, value);
        }
    }
}
