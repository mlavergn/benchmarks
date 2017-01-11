import Foundation

func FileTest(_ path:String) -> Array<Array<String>> {
	let raw = try! String(contentsOf:URL(string:path)!, encoding:String.Encoding.utf8)
	let lines = raw.components(separatedBy: "\n")

	var data:Array<Array<String>> = Array(repeating:[], count:lines.count)

	var i = 0
	let trimSet = CharacterSet.init(charactersIn:"'")
	for line in lines {
		let fields  = line.components(separatedBy: ",")
		data[i] = fields
		var j = 0
		for field in fields {
			data[i][j] = field.trimmingCharacters(in:trimSet)
			j += 1
		}
		i += 1
	}
	return data
}

var path = FileManager.default.currentDirectoryPath

let startTime = CFAbsoluteTimeGetCurrent()
let data = FileTest("file://" + path + "/../employees.txt")
print(Double(CFAbsoluteTimeGetCurrent() - startTime) * 1000.0)

if data.count < 0 {
	
}
