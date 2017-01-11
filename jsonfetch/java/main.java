import java.net.*;
import java.io.*;
import java.util.stream.*;
import javax.script.*;

class Main {
	public String JSONTest(String urlString) throws Exception {
		URL url = new URL(urlString);
		URLConnection req = url.openConnection();
		req.setRequestProperty("User-Agent", "Mozilla/5.0 (iPhone; CPU iPhone OS 10_2 like Mac OS X) AppleWebKit/602.3.12 (KHTML, like Gecko) Version/10.0 Mobile/14C92 Safari/602.1");
		
		BufferedReader resp = new BufferedReader(new InputStreamReader(req.getInputStream()));
		String data = resp.lines().collect(Collectors.joining("\n"));
		resp.close();
		
		ScriptEngine engine = new ScriptEngineManager().getEngineByName("nashorn");
		engine.eval("x=" + data);
		return (String)engine.eval("x['ip']");
	}

	public static void main(String[] args) 
	{
		try {
			long startTime = System.nanoTime();    
			Main test = new Main();
			test.JSONTest("http://iotjson.appspot.com");
			System.out.println((System.nanoTime() - startTime) / 1000000.0);
		} catch (Exception e) {

		}
	}
}
