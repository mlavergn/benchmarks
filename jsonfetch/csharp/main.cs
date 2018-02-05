using System;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

class JsonFetch {
	static string JsonTest(string url) {
		// perform the request
		HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
		request.Method = "GET";
		request.UserAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 10_2 like Mac OS X) AppleWebKit/602.3.12 (KHTML, like Gecko) Version/10.0 Mobile/14C92 Safari/602.1";
		WebResponse response = request.GetResponse();

		// read the result
		Stream stream = response.GetResponseStream();

		// convert the JSON
		var ser = new DataContractJsonSerializer(typeof(IOT));
		IOT x = (IOT)ser.ReadObject(stream);

		return x.IP;
	}
	
	static void Main(string[] args) {
		Stopwatch sw = Stopwatch.StartNew();
		string data = JsonTest("http://iotjson.appspot.com");
		sw.Stop();
		Console.Write(sw.ElapsedMilliseconds);
		Console.WriteLine(" ms");
		Console.WriteLine(data);
		if (data.Length < 0) {
		} 
	}
}

[DataContract]
class IOT
{
    [DataMember(Name="host")] public string Host { get; set; }
    [DataMember(Name="ip")] public string IP { get; set; }
}