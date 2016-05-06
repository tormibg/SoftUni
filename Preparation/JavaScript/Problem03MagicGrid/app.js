function solve(arr) {
    var inpText = arr[0];
    var newTxt = "";
    var magicNumbers = Number(arr[1]);
    
    var matrix = [];
    var i;
    for (i = 2; i < arr.length; i++) {
        var tmpArr = arr[i].split(/\s/).map(function (num) {
            return Number(num);
        });
        matrix.push(tmpArr);
    }
    var cordNum = checkMatrix(matrix);
    
    for (var ch in inpText) {
        if (inpText.hasOwnProperty(ch)) {
            var newCh;
            ch = Number(ch);
            if (ch % 2) {
                newCh = String.fromCharCode(inpText[ch].charCodeAt(0) - cordNum);
            } else {
                newCh = String.fromCharCode(inpText[ch].charCodeAt(0) + cordNum);
            }
            newTxt += newCh;
        };
    };
    console.log(newTxt);
    
    function checkMatrix(matrix) {
        for (i = 0; i < matrix.length; i++) {
            for (var j = 0; j < matrix[i].length; j++) {
                var firstNum = matrix[i][j];
                for (var k = 0; k < matrix.length; k++) {
                    for (var l = 0; l < matrix[k].length; l++) {
                        var secNum = matrix[k][l];
                        if (!(i === k && j === l)) {
                            if (firstNum + secNum === magicNumbers) {
                                return i + j + k + l;
                            }
                        }
                    }
                }
            }
        }
    }
};

var arr = ["Vi`ujr!sihtudts", '0', '0 0 120', '120 300 310', '150 290 370'];

solve(arr);