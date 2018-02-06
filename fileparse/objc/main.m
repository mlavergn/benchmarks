#import <Foundation/Foundation.h>

NSArray<NSArray<NSString *>*>* fileTest(NSString *path) {
	NSURL *url = [NSURL URLWithString:path];

	NSError *err;
	NSStringEncoding enc;
	NSString *raw = [NSString stringWithContentsOfURL:url encoding:NSUTF8StringEncoding error:&err];

	NSArray<NSString *>* lines = [raw componentsSeparatedByCharactersInSet:[NSCharacterSet characterSetWithCharactersInString:@"\n"]];

	NSMutableArray *data = [NSMutableArray arrayWithCapacity:[lines count]];

	NSCharacterSet *fieldSet = [NSCharacterSet characterSetWithCharactersInString:@","];
	NSCharacterSet *trimSet = [NSCharacterSet characterSetWithCharactersInString:@"'"];

	for (NSString *line in lines) {
		NSArray *fields = [line componentsSeparatedByCharactersInSet:fieldSet];
		NSMutableArray *fieldArr = [NSMutableArray arrayWithCapacity:fields.count];
		NSInteger i = 0;
		for (NSString *field in fields) {
			fieldArr[i] = [field stringByTrimmingCharactersInSet:trimSet];
			i += 1;

		}
		[data addObject:fieldArr];
	}

	return data;
}

int main(int argc, char *argv[]) {
    @autoreleasepool {
		NSString *cwd = [[NSFileManager defaultManager] currentDirectoryPath];
		NSString *path = [NSString stringWithFormat:@"file://%@/../employees.txt", cwd];
		NSLog(@"%@", path);

		NSTimeInterval startTime = CFAbsoluteTimeGetCurrent();
		NSArray *data = fileTest(path);
		NSLog(@"%f ms - cold", (CFAbsoluteTimeGetCurrent() - startTime) * 1000.0);

		startTime = CFAbsoluteTimeGetCurrent();
		data = fileTest(path);
		NSLog(@"%f ms - warm", (CFAbsoluteTimeGetCurrent() - startTime) * 1000.0);

		if (data.count < 30000) {
			NSLog(@"failed");
		}
    }
}
