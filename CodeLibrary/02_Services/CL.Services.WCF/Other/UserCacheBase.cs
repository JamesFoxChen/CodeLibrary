using System;
using System.Web;
using System.Web.Caching;

namespace CL.Services.WCF
{
    /// <summary>
    /// 用户缓存操作类
    /// </summary>
    public class UserCacheBase
    {
        /// <summary>
        /// 验证成功返回实体；失败返回null
        /// </summary>
        /// <param name="userStateId">用户验证串</param>
        /// <returns></returns>
        public static UserInfoCache VerifyUserInfo(string userStateId)
        {
            //1、判断userStateId是否在缓存key中
            //   1.1、存在：表示验证成功。从缓存中读取用户信息，并返回
            //   1.2、不存在：表示验证失败。直接返回null

            var cache = HttpRuntime.Cache;
            if (cache[userStateId] == null) //无缓存数据
            {
                return null;
            }

            UserInfoCache userInfo = cache[userStateId] as UserInfoCache;
            return userInfo;
        }

        /// <summary>
        /// 新增缓存成功返回用户验证串；失败返回null
        /// </summary>
        /// <param name="userInfoCache">用户信息</param>
        /// <returns></returns>
        public static string AddUserCache(UserInfoCache userInfoCache)
        {
            //1、生成用户GUID
            //2、将用户GUID和用户信息添加到缓存中(缓存使用相对过期，失效时间从配置文件中读取，单位为分钟)
            //3、返回用户GUID

            string userStateId = Guid.NewGuid().ToString();


            //相对到期时间(分钟)
            var interval = 10;// ConfigUtil.CacheExpireTime;
            var cache = HttpRuntime.Cache;
            cache.Insert(userStateId, userInfoCache, null, Cache.NoAbsoluteExpiration,
                         new TimeSpan(0, interval, 0), CacheItemPriority.Default, cachedItemRemoveCallBack);
            return userStateId;
        }

        /// <summary>
        /// 缓存到期后的回调函数
        /// </summary>
        /// <param name="key">缓存名称</param>
        /// <param name="value">缓存的值</param>
        /// <param name="reason">缓存到期的原因</param>
        private static void cachedItemRemoveCallBack(string key, object value,
                 CacheItemRemovedReason reason)
        {
        }
    }

    /// <summary>
    /// 存入缓存的用户信息
    /// </summary>
    public class UserInfoCache
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int? CustomerId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 登陆名称
        /// </summary>
        public string LoginName { get; set; }

        ///// <summary>
        ///// 登陆密码
        ///// </summary>
        //public string LoginPwd { get; set; }

        /// <summary>
        /// 应用程序类型（0:ios  1-android)）
        /// </summary>
        public int? AppType { get; set; }

        /// <summary>
        ///手机系统类型(0:ios  1-android)
        /// </summary>
        public int? PhoneType { get; set; }

        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// IMEI号
        /// </summary>
        public string Imei { get; set; }

        /// <summary>
        /// Mac地址
        /// </summary>
        public string Mac { get; set; }
               
    }
}
