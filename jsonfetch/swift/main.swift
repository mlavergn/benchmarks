import Foundation

func JSONTest(_ urlString:String) -> String {
	let url = URL(string: urlString)
	var request = URLRequest.init(url: url!)
	request.setValue("Mozilla/5.0 (iPhone; CPU iPhone OS 10_2 like Mac OS X) AppleWebKit/602.3.12 (KHTML, like Gecko) Version/10.0 Mobile/14C92 Safari/602.1", forHTTPHeaderField: "User-Agent")
	request.httpMethod = "GET"
	
	let session = URLSession.shared
	
	var bytes: Data?
	let semaphore = DispatchSemaphore(value: 0)
	session.dataTask(with:request) { (data, response, error) -> Void in
		bytes = data
		semaphore.signal()
	}.resume()
	_ = semaphore.wait(timeout: .distantFuture)
	
	do {
		let json = try 	JSONSerialization.jsonObject(with: bytes!, options: .allowFragments)
		let jsonMap = json as! NSDictionary
		return jsonMap["ip"] as! String
	} catch {
		print(error)
		return ""
	}
}

let startTime = CFAbsoluteTimeGetCurrent()
_ = JSONTest("http://iotjson.appspot.com")
print(Double(CFAbsoluteTimeGetCurrent() - startTime) * 1000.0)
