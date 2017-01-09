using System;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;

using Newtonsoft.Json;

class JsonFetch {
	// fetch on a background thread
	static async Task<String> JsonTest() {
		var url = "http://iotjson.appspot.com";
		HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
		request.ContentType = "application/json";
		request.Method = "GET";
		using (WebResponse response = await request.GetResponseAsync()) {
			Stream stream = response.GetResponseStream();
			StreamReader stramreader = new StreamReader(stream);

			String responseData = stramreader.ReadToEnd();

			var x = JsonConvert.DeserializeObject<dynamic>(responseData);

			return x.ip.Value;
		}
	}
	
	static void Main(string[] args) {
		GC.Collect();
		Stopwatch sw = Stopwatch.StartNew();
		
		// blocks until return
		string x = JsonTest().Result;
		
		sw.Stop();
		Console.WriteLine(sw.ElapsedMilliseconds);
	}
}
