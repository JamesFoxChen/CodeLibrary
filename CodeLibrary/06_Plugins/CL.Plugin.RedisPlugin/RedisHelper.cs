using System;
using System.Collections.Generic;

namespace CL.Plugin.RedisPlugin
{
    public class RedisHelper
    {
        /// <summary>
        /// 获取值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            using (var redis = RedisConfig.Redis)
            {
                return redis.Get<T>(key);
            }
        }

        /// <summary>
        /// 设置值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Set<T>(string key, T value)
        {
            using (var redis = RedisConfig.Redis)
            {
                return redis.Set<T>(key, value);
            }
        }

        /// <summary>
        /// 设置值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Set<T>(string key, T value, DateTime dt)
        {
            using (var redis = RedisConfig.Redis)
            {
                return redis.Set<T>(key, value, dt);
            }
        }

        /// <summary>
        /// 移除单个值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(string key)
        {
            using (var redis = RedisConfig.Redis)
            {
                return redis.Remove(key);
            }
        }

        /// <summary>
        /// 移除集合值
        /// </summary>
        /// <param name="keys"></param>
        public void RemoveList(List<string> keys)
        {
            using (var redis = RedisConfig.Redis)
            {
                foreach (var key in keys)
                {
                    redis.Remove(key);
                }
            }
        }
    }
}
