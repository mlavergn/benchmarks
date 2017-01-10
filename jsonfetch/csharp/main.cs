using System;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;

using Newtonsoft.Json;

class JsonFetch {
	static string JsonTest(string url) {
		// perform the request
		HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
		request.Method = "GET";
		request.ContentType = "application/json";
		WebResponse response = request.GetResponse();

		// read the result
		Stream stream = response.GetResponseStream();
		StreamReader streamreader = new StreamReader(stream);
		String responseData = streamreader.ReadToEnd();

		// convert the JSON
		var x = JsonConvert.DeserializeObject<dynamic>(responseData);

		// return a string field
		return x.ip.Value;
	}
	
	static void Main(string[] args) {
		Stopwatch sw = Stopwatch.StartNew();
		JsonTest("http://iotjson.appspot.com");
		sw.Stop();
		Console.WriteLine(sw.ElapsedMilliseconds);
	}
}
