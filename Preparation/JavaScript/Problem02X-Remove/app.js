function solve(arr) {
    var oldMatrix = [];
    var newMatrix = [];
    arr.forEach(function (str) {
        oldMatrix.push(str.toLowerCase().split(''));
        newMatrix.push(str.split(''));
    });
    for (var row = 0; row < oldMatrix.length - 2; row++) {
        for (var col = 0; col < oldMatrix[row].length - 2; col++) {
            var chSel = oldMatrix[row][col];
            if (chSel === oldMatrix[row][col + 2] &&
                chSel === oldMatrix[row + 1][col + 1] &&
                chSel === oldMatrix[row + 2][col] &&
                chSel === oldMatrix[row + 2][col + 2]
                ) {
                //console.log(row,col);
                newMatrix[row][col] = " ";
                newMatrix[row][col + 2] = " ";
                newMatrix[row + 1][col + 1] = " ";
                newMatrix[row + 2][col] = " ";
                newMatrix[row + 2][col + 2] = " ";
            }
        }
    }
    for (var lineIndex in newMatrix) {
        console.log(newMatrix[lineIndex].join('').split(' ').join(''));
    }
};

var arr = ['abnbjs', 'xoBab', 'Abmbh', 'aabab', 'ababvvvv'];
var arr = ['8888888', '08*8*80', '808*888', '0**8*8?'];
var arr = ['^u^', 'j^l^a', '^w^WoWl', 'adw1w6', '(WdWoWgPoop)'];
var arr = [
    'puoUdai',
    'miU',
    'ausupirina',
    '8n8i8',
    'm8o8a',
    '8l8o860',
    'M8i8',
    '8e8!8?!'
];

solve(arr);