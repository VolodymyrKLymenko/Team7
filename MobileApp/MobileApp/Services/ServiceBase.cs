using MobileApp.Models.Events;
using MobileApp.Services.LiteDB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Services
{
    class ServiceBase
    {
        protected HttpClient client => HttpSingleton.Get();
		protected LiteDBService liteContext => LiteDBSingleton.Get();
		protected HttpClientHandler handler => HttpSingleton.GetHandler();

		protected static List<Event> favoureEvents;

		private string _prefix;
		protected string prefix
		{
			get
			{
				return _prefix;
			}
			set
			{
				if (value.StartsWith("/"))
					_prefix = value.Remove(0, 1);
				else _prefix = value;
			}
		}

		public static T Deserialize<T>(string json)
		{
			return JsonConvert.DeserializeObject<T>(json);
		}

		public static string Serialize(object o)
		{
			return JsonConvert.SerializeObject(o);
		}

		public async Task<string> Get(string url, params KeyValuePair<string, string>[] param)
		{
			url = urlP(url);
			if (param != null && param.Length > 0)
			{
				for (int i = 0; i < param.Length; i++)
				{
					if (i != 0)
					{
						url += $"&{param[i].Key}={param[i].Value}";
					}
					else
					{
						url += $"?{param[i].Key}={param[i].Value}";
					}
				}
			}

			var resp = await client.GetAsync(url);

			var json = await resp.Content.ReadAsStringAsync();

			Debug.WriteLine("*********GET********");
			Debug.WriteLine($"{client.BaseAddress}{url}");
			Debug.WriteLine(json);
			Debug.WriteLine("*********GET********");

			return json;
		}

		public async Task<string> Post(string url, object o)
		{
			var _url = url;
			url = urlP(url);

			HttpResponseMessage resp;
			Debug.WriteLine("*********POST********");
			if (o != null)
			{
				string d = Serialize(o);
				Debug.WriteLine("Sent:");
				Debug.WriteLine(d);
				Debug.WriteLine("*********Response:********");
				var buffer = System.Text.Encoding.UTF8.GetBytes(d);
				var byteContent = new ByteArrayContent(buffer);
				byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

				resp = await client.PostAsync(url, byteContent);
			}
			else
			{
				resp = await client.PostAsync(url, null);
			}

			string data = await resp.Content.ReadAsStringAsync();

			Debug.WriteLine($"{client.BaseAddress}{url}");
			Debug.WriteLine(data);
			Debug.WriteLine(resp.StatusCode);
			Debug.WriteLine("*********POST********");
			return data;
		}

		private string urlP(string url)
		{
			if (url.StartsWith("/"))
			{
				url = url.Remove(0, 1);
			}
			return prefix + "/" + url;
		}
	}
}
