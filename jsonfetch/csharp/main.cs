using System;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

class JsonFetch {
	static string JsonTest(string url) {
		// perform the request
		HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
		request.Method = "GET";
		request.UserAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 10_2 like Mac OS X) AppleWebKit/602.3.12 (KHTML, like Gecko) Version/10.0 Mobile/14C92 Safari/602.1";
		WebResponse response = request.GetResponse();

		// read the result
		Stream stream = response.GetResponseStream();
		StreamReader streamreader = new StreamReader(stream);
		String responseData = streamreader.ReadToEnd();

		// convert the JSON
		JObject x = JObject.Parse(responseData);

		return (string)x["ip"];
	}
	
	static void Main(string[] args) {
		Stopwatch sw = Stopwatch.StartNew();
		string data = JsonTest("http://iotjson.appspot.com");
		sw.Stop();
		Console.WriteLine(sw.ElapsedMilliseconds);
		if (data.Length < 0) {
		} 
	}
}
