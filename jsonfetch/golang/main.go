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
	req.Header.Add("User-Agent", "Mozilla/5.0 (iPhone; CPU iPhone OS 10_2 like Mac OS X) AppleWebKit/602.3.12 (KHTML, like Gecko) Version/10.0 Mobile/14C92 Safari/602.1")
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
	data := JSONTest("http://iotjson.appspot.com")
	log.Println(time.Since(timerShared))
	log.Println(data)
}
