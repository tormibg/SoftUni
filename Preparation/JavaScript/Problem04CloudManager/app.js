function solve(arr) {
    var result = {};
    var getAvg = function (memory) {
        var sum = 0;
        for (var num in memory) {
            sum += Number(memory[num]);
        }
        return sum.toFixed(2);
    };
    for (var lineIndex in arr) {
        var lines = arr[lineIndex].trim().split(/\s+/g);
        var fileName = lines[0].trim();
        var fileExt = lines[1].trim();
        var fileSize = parseFloat(lines[2]);
        //console.log(fileSize);
        if (!result[fileExt]) {
            result[fileExt] = {
                files: [],
                memory: []
            };
        }
        result[fileExt].files.push(fileName);
        result[fileExt].memory.push(fileSize);
    }
    var sortedExt = Object.keys(result);
    sortedExt.sort();
    var sortedResult = {};
    for (var i in sortedExt) {
        var nameExt = sortedExt[i];
        sortedResult[nameExt] = result[nameExt];
        sortedResult[nameExt].files.sort();
        sortedResult[nameExt].memory = getAvg(sortedResult[nameExt].memory);
    }
    console.log(JSON.stringify(sortedResult));
};

//var arr = [
//    'sentinel .exe 15MB',
//    'zoomIt .msi 3MB',
//    'skype .exe 45MB',
//    'trojanStopper .bat 23MB',
//    'kindleInstaller .exe 120MB',
//    'setup .msi 33.4MB',
//    'winBlock .bat 1MB'
//];

var arr = [
    'eclipse .tar.gz 198.00MB',
    'uTorrent .gyp 33.02MB',
    'nodeJS .gyp 14MB',
    'nakov-naked .jpeg 3MB',
    'gnuGPL .pdf 5.6MB',
    'skype .tar.gz 66MB',
    'selfie .jpeg 7.24MB',
    'myFiles .tar.gz 783MB'
];

solve(arr);