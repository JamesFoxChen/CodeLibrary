using System.Configuration;
using ServiceStack.Redis;

namespace CL.Plugin.RedisPlugin
{
    public class RedisConfig
    {
        public static RedisClient Redis
        {
            get
            {
                return (RedisClient)reidsPools.GetClient();
            }
        }

        private static string[] hosts;
        private static PooledRedisClientManager reidsPools;

        static RedisConfig()
        {
            var hosts = ConfigurationManager.AppSettings["RedisServer"].Split(',');

            reidsPools = new PooledRedisClientManager(hosts, hosts, new RedisClientManagerConfig
            {
                MaxWritePoolSize = 100,//“写”链接池链接数
                MaxReadPoolSize = 200,//“读”链接池链接数
                AutoStart = true,
                DefaultDb = 0
            });
        }
    }
}
