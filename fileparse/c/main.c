#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>
#include <unistd.h>
#include <sys/time.h>
#include <string.h>

#define LogConsole(string, ...) fprintf(stderr, "%s@%i: " string "\n", __FUNCTION__, __LINE__, ## __VA_ARGS__)

char** fileparse(char *path) {
	FILE *fh = fopen(path,"r");
	if (fh == 0) {
		return NULL;
	}

	// determine the file size
	fseek(fh, 0L, SEEK_END);
	int size = ftell(fh);
	fseek(fh, 0L, SEEK_SET);
	LogConsole("%d", size);

	// read it in
	char *buf = (char *)malloc(size);
  	fread(buf, 1, size, fh);
	fclose(fh);

	// split it into lines
	int cols = 6;
	char **result  = calloc(sizeof(char*), size);
	int line = 0;

	int loffset = 0;
	for (int i=0; i<size; i++) {
		if (buf[i] == '\n' || i == size-1) {
			buf[i] = 0;
			// LogConsole("%s", &buf[line]);
			int field = 0;
			int foffset = loffset;
			for (int j=loffset; j<=i; j++) {
				if (buf[j] == ',' || j == i) {
					if (buf[foffset] == '\'' ) {
						foffset += 1;
					}
					if (buf[j-1] == '\'') {
						buf[j-1] = 0;
					} else {
						buf[j] = 0;
					}
					// result[(line * cols) + field] = &buf[foffset];
					result[(line * cols) + field] = &buf[foffset];
					field++;
					foffset = j+1;
				}
			}
			line++;
			loffset = i+1;
		}
	}

	return result;
}

int main(int argc, const char * argv[]) 
{
	char *cwd = getcwd(NULL, 0);
	char path[1024];
	sprintf(path, "%s/../employees.txt", cwd);
	LogConsole("%s", path);

	struct timeval startTime;
	struct timeval endTime;
	struct timeval elapsedTime;
	gettimeofday(&startTime, NULL);

	char **data = fileparse(path);
	free(data);

	gettimeofday(&endTime, NULL); 
  	timersub(&endTime, &startTime, &elapsedTime);
  	int elapsed = (int)((elapsedTime.tv_sec * 1000) + elapsedTime.tv_usec);
	LogConsole("%i ms - cold", elapsed / 1000);

	// for (int i=0; i<300024*6; i+=6) {
	// 	LogConsole("%s %s %s %s %s %s", data[i+0], data[i+1], data[i+2], data[i+3], data[i+4], data[i+5]);
	// }

	gettimeofday(&startTime, NULL);

	data = fileparse(path);
	free(data);

	gettimeofday(&endTime, NULL); 
  	timersub(&endTime, &startTime, &elapsedTime);
  	elapsed = (int)((elapsedTime.tv_sec * 1000) + elapsedTime.tv_usec);
	LogConsole("%i ms - warm", elapsed / 1000);

	return 0;
}
