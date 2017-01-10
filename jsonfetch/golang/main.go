package main

import (
	"encoding/json"
	"io/ioutil"
	"log"
	"net/http"
	"time"
)

func JSONTest(url string) string {
	// perform the request
	req, _ := http.NewRequest("GET", url, nil)
	req.Header.Add("Content-Type", "application/json")
	client := &http.Client{}
	resp, _ := client.Do(req)

	// read the result
	bytes, _ := ioutil.ReadAll(resp.Body)

	// convert the JSON
	var jsonMap map[string]interface{}
	json.Unmarshal(bytes, &jsonMap)

	// return a string field
	return jsonMap["ip"].(string)
}

func main() {
	timerShared := time.Now()
	JSONTest("http://iotjson.appspot.com")
	log.Println(time.Since(timerShared))
}
