function solve(arr) {
    var tCount = { 'I': 0, 'L': 0, 'J': 0, 'O': 0, 'Z': 0, 'S': 0, 'T': 0 };
    
    for (var row = 0; row < arr.length; row++) {
        for (var col = 0; col < arr[row].length; col++) {
            if (arr[row][col] === 'o') {
                for (var item in tCount) {
                    checkFig(item, row, col);
                }
            }
        }
    }
    console.log(JSON.stringify(tCount));
    
    function checkFig(item, row, col) {
        switch (item) {
            case 'I':
                checkEl(item, row, col, 1, 0, 2, 0, 3, 0);
                break;
            case 'L':
                checkEl(item, row, col, 1, 0, 2, 0, 2, 1);
                break;
            case 'J':
                checkEl(item, row, col, 1, 0, 2, 0, 2, -1);
                break;
            case 'O':
                checkEl(item, row, col, 0, 1, 1, 0, 1, 1);
                break;
            case 'Z':
                checkEl(item, row, col, 0, 1, 1, 1, 1, 2);
                break;
            case 'S':
                checkEl(item, row, col, 0, -1, 1, -1, 1, -2);
                break;
            case 'T':
                checkEl(item, row, col, 0, 1, 1, 1, 0, 2);
                break;
        }
    }
    
    function checkEl(elem, row, col, firstRowCheck, firstColCheck,
                                     secondRowCheck, secondColCheck,
                                     thirdRowCheck, thirdColCheck) {
        var maxRow = Math.max(firstRowCheck, secondRowCheck, thirdRowCheck);
        var maxCol = Math.max(firstColCheck, secondColCheck, thirdColCheck);
        var minCol = Math.min(firstColCheck, secondColCheck, thirdColCheck);
        if (arr[row + maxRow] == undefined || 
            arr[row + maxRow][col + maxCol] == undefined || 
            arr[row][col + minCol] == undefined) {
            return false;
        }
        if (arr[row][col] === arr[row + firstRowCheck][col + firstColCheck] &&
            arr[row][col] === arr[row + secondRowCheck][col + secondColCheck] &&
            arr[row][col] === arr[row + thirdRowCheck][col + thirdColCheck]) {
            tCount[elem]++;
        }
    }

};

var arr = ['--o--o-', '--oo-oo', 'ooo-oo-', '-ooooo-', '---oo--'];

// var arr = ['-oo', 'ooo', 'ooo'];

solve(arr);