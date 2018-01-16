function solve(arr) {
    var numConsEl = parseInt(arr.pop());
    var oldMatrix = [];
    
    for (var lineIndex in arr) {
        var lines = arr[lineIndex].trim();
        oldMatrix.push(lines.split(' '));
    }
    
  //  console.log(oldMatrix);

    var matrixArray = [];
    var row;
    var col;
    for (row = 0; row < oldMatrix.length; row++) {
        for (col = 0; col < oldMatrix[row].length; col++) {
            matrixArray.push(oldMatrix[row][col]);
        }
    }

  //  console.log(matrixArray);

    var sec = 1;
    var prevNum = matrixArray[0];
    var i;
    for (i = 1; i < matrixArray.length; i++) {
        if (sec === 0) {
            prevNum = matrixArray[i];
            sec = 1;
        } else {
           if (prevNum.localeCompare(matrixArray[i]) === 0) {
            //if (prevNum == matrixArray[i]) {
                sec++;
                if (sec === numConsEl) {
                    for (var j = 0; j < sec; j++) {
                        matrixArray[i - j] = null;
                    }
                    sec = 0;
                }
            } else {
                prevNum = matrixArray[i];
                sec = 1;
            }
        }
    }
  //  console.log(matrixArray);
    i = 0;
    for (row = 0; row < oldMatrix.length; row++) {
        for (col = 0; col < oldMatrix[row].length; col++, i++) {
            oldMatrix[row][col] = matrixArray[i];
        }
    }
    
  //  console.log(oldMatrix);

    for (row = 0; row < oldMatrix.length; row++) {
        var lineToPrint = "";
        for (col = 0; col < oldMatrix[row].length; col++) {
            if (oldMatrix[row][col]) {
                lineToPrint += ' ' + oldMatrix[row][col];
            }
        }
        if (lineToPrint.length !== 0) {
            console.log(lineToPrint.trim());
        } else {
            console.log('(empty)');
        }
    }
};

//var arr = [
//    '3 3 3 2 5 9 9 9 9 1 2',
//    '1 1 1 1 1 2 5 8 1 1 7',
//    '7 7 1 2 3 5 7 4 4 1 2',
//    '2'
//];

//var arr = ['1 2 3 3', '3 5 7 8', '3 2 2 1', '3'];
//var arr = ['2 1 1 1', '1 1 1', '3 7 3 3 1', '2'];
//var arr = ['1 2 3 3 2 1', '5 2 2 1 1 0', '3 3 1 3 3', '2'];

var arr =  ['1 01 10 10',' B B B B' , '2'];

solve(arr);