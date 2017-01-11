package main

import (
	"io/ioutil"
	"log"
	"os"
	"strings"
	"time"
)

func FileTest(path string) (result [][]string) {
	bytes, _ := ioutil.ReadFile(path)
	str := string(bytes)
	lines := strings.Split(str, "\n")

	result = make([][]string, len(lines))
	for i, line := range lines {
		fields := strings.Split(line, ",")
		if len(fields) < 6 {
			log.Println("error")
			break
		}
		result[i] = fields
		for j, field := range fields {
			result[i][j] = strings.Trim(field, "'")
		}
	}

	return
}

func main() {
	cwdPath, _ := os.Getwd()
	filePath := cwdPath + "/../employees.txt"

	var timer time.Time
	timer = time.Now()

	data := FileTest(filePath)
	log.Println(time.Since(timer))

	if len(data) < 300000 {
		log.Println("failed")
	}
}