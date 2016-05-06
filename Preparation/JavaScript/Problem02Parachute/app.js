function solve(arr) {
    var startRow = 0;
    var startCol = 0;
    for (var i in arr) {
        var pos = arr[i].indexOf('o');
        if (pos !== -1) {
            startRow = Number(i);
            startCol = Number(pos);
            break;
        }
    }
    for (var row = startRow + 1; row < arr.length; row++) {
        for (var j in arr[row]) {
            if (arr[row][j] === ">") {
                startCol++;
            }
            if (arr[row][j] === "<") {
                startCol--;
            }
        }
        if (arr[row][startCol] === "_") {
            console.log("Landed on the ground like a boss!\n" + row, startCol);
            return;
        };
        if (arr[row][startCol] === "~") {
            console.log("Drowned in the water like a cat!\n" + row, startCol);
            return;
        };
        if (arr[row][startCol] === "/" || arr[row][startCol] === "\\" || arr[row][startCol] === "|") {
            console.log("Got smacked on the rock like a dog!\n" + row, startCol);
            return;
        };
    }
};

var arr = [
    '-------------o-<<--------',
    '-------->>>>>------------',
    '---------------->-<---<--',
    '------<<<<<-------/\\--<--',
    '--------------<--/-<\\----',
    '>>--------/\\----/<-<-\\---',
    '---------/<-\\--/------\\--',
    '<-------/----\\/--------\\-',
    '\\------/--------------<-\\',
    '-\\___~/------<-----------'
];

solve(arr);