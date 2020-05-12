using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace MobileApp.Services
{
	public static class HttpSingleton
	{
		static HttpClient client;
		static HttpClientHandler httpClientHandler;

		public static HttpClient Get(string base_url = null)
		{
			if (client == null)
			{
				httpClientHandler = new HttpClientHandler
				{
					UseCookies = true,
					CookieContainer = new CookieContainer(),
					ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; } // Temp Property
				};
				client = new HttpClient(httpClientHandler);

				if (!string.IsNullOrWhiteSpace(base_url)) client.BaseAddress = new Uri(base_url);
			}

			return client;
		}

		public static HttpClientHandler GetHandler()
		{
			return httpClientHandler;
		}
	}
}
