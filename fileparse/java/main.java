import java.io.*;
import java.nio.file.*;
import java.util.Iterator;
import java.util.stream.*;

public class main {
	static String[][] fileTest(String path) {
		try {
			Path filePath = Paths.get(path);
			int lineCount = (int)Files.lines(filePath).count();
			String[][] result = new String[lineCount][];

			Stream<String> lines = Files.lines(filePath);
			Iterator<String> iterator = lines.iterator();

			int i = 0;
			while (iterator.hasNext()) {
				String line = iterator.next();
				String[] fields = line.split(",");
				if (fields.length < 6) {
					System.out.println("error");
					break;
				}
				result[i] = fields;
				for (int j=0; j<result[i].length; j++) {
					String field = result[i][j];
					field = field.replaceFirst("[']+$", "");	
					field = field.replaceFirst("^[']+", "");	
					result[i][j] = field;
				}
				i++;
			};

			return result;
		} catch (Exception e) {
			System.out.println(e);
			return null;
		}
	}

	public static void main(String[] args) {
		System.out.println("test");

		String cwdPath = System.getProperty("user.dir");
		String filePath = cwdPath + "/../employees.txt";
		System.out.println(filePath);

		long timer = System.currentTimeMillis();
		String[][] data = fileTest(filePath);
		System.out.print(System.currentTimeMillis() - timer);
		System.out.println("ms -cold");		

		timer = System.currentTimeMillis();
		data = fileTest(filePath);
		System.out.print(System.currentTimeMillis() - timer);
		System.out.println("ms - warm");		

		if (data.length < 30000) {
			System.out.println("failed");
		}
	}
}