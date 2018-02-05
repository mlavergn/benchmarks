using System;
using System.IO;
using System.Diagnostics;

class Untitled
{
	static string[][] FileTest(string path)
	{
		string[] lines = System.IO.File.ReadAllLines(path);
		string[][] data = new string[lines.Length][];
		int i = 0;
		char[] delim = {','};
		char[] trim = {'\''};
		foreach (string line in lines)
		{
			data[i] = line.Split(delim);
			int j = 0;
			foreach (string field in data[i]) {
				data[i][j] = field.Trim(trim);
				j += 1;
			}
			i += 1;
		}
		
		return data;
	}
	
	static void Main(string[] args)
	{
		string path = Directory.GetCurrentDirectory() + "/../employees.txt";

		Stopwatch sw = Stopwatch.StartNew();
		string[][] data = FileTest(path);
		sw.Stop();
		Console.Write(sw.ElapsedMilliseconds);
		Console.WriteLine("ms - cold");

		sw = Stopwatch.StartNew();
		string[][] data2 = FileTest(path);
		sw.Stop();
		Console.Write(sw.ElapsedMilliseconds);
		Console.WriteLine("ms - warm");

		if (data.Length < 30000) {
			Console.WriteLine("error");
		}
	}
}