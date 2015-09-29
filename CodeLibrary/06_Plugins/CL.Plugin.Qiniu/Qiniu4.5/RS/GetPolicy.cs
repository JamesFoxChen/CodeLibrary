﻿using System;
using Qiniu.Auth.digest;
using CL.Plugin.Qiniu;

namespace Qiniu.RS
{
	/// <summary>
	/// GetPolicy
	/// </summary>
	public class GetPolicy
	{
		public static string MakeRequest (string baseUrl, UInt32 expires = 3600, Mac mac = null)
		{
			if (mac == null) {
                mac = new Mac(QiniuConfig.ACCESS_KEY, QiniuConfig.Encoding.GetBytes(QiniuConfig.SECRET_KEY));
			}

			UInt32 deadline = (UInt32)((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000 + expires);
			if (baseUrl.Contains ("?")) {
				baseUrl += "&e=";
			} else {
				baseUrl += "?e=";
			}
			baseUrl += deadline;
            string token = mac.Sign(QiniuConfig.Encoding.GetBytes(baseUrl));
			return string.Format ("{0}&token={1}", baseUrl, token);
		}

		public static string MakeBaseUrl (string domain, string key)
		{
			key = Uri.EscapeUriString (key);
			return string.Format ("http://{0}/{1}", domain, key);
		}
	}
}
