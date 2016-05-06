function solve(arr) {
    var chSel;
    var maxRowLen = arr.length - 2;
    var cord = [];
    var newMatrix = [], matrix = [];
    var row;
    var col;
    arr.forEach(function (str) {
        matrix.push(str.toLowerCase().split(''));
        newMatrix.push(str.split(''));
    });
    
    for (row = 0; row < maxRowLen; row++) {
        for (col = 0; col < arr[row].length; col++) {
            //checkPlus(row, col);
            chSel = matrix[row][col];
            if (chSel === matrix[row + 1][col] &&
                chSel === matrix[row + 1][col - 1] &&
                chSel === matrix[row + 1][col + 1] &&
                chSel === matrix[row + 2][col]) {
                newMatrix[row][col] =' ';
                newMatrix[row + 1][col] = ' ';
                newMatrix[row + 1][col - 1] = ' ';
                newMatrix[row + 1][col + 1] = ' ';
                newMatrix[row + 2][col] = ' ';
            }
        }
    };
    
    newMatrix.forEach(function(str) {
        console.log(str.join('').replace(/\s+/g,''));
    });

    //for (row = 0; row < arr.length; row++) {
    //    var newStr = "";
    //    for (col = 0; col < arr[row].length; col++) {
    //        var found = cord.filter(function (a) {
    //            return a[0] === row && a[1] === col;
    //        });
    //        if (found.length == 0) {
    //            newStr += arr[row][col];
    //        }
    //    }
    //    console.log(newStr);
    //}
    //// console.log(newMatrix);

    //function checkPlus(row, col) {
    //    if (col - 1 >= 0 && ((col + 1) <= (arr[row + 1].length - 1)) && ((row + 2) <= arr.length - 1) && (col <= arr[row+2].length-1)) {
    //        chSel = arr[row][col].toLowerCase();
    //        //console.log(row,col);
    //        if (chSel === arr[row + 1][col].toLowerCase() &&
    //            chSel === arr[row + 1][col - 1].toLowerCase() &&
    //            chSel === arr[row + 1][col + 1].toLowerCase() &&
    //            chSel === arr[row + 2][col].toLowerCase()) {
    //            cord.push([row, col]);
    //            cord.push([row + 1, col - 1]);
    //            cord.push([row + 1, col]);
    //            cord.push([row + 1, col + 1]);
    //            cord.push([row + 2, col]);
    //        }
    //    }
    //}
};

var arr = ['ab**l5', 'bBb*555', 'absh*5', 'ttHHH', 'ttth'];
//var arr = ['888**t*', '8888ttt', '888ttt<<', '*8*0t>>hi'];
//var arr = [
//    '@s@a@p@una',
//    'p@@@@@@@@dna',
//    '@6@t@*@*ego',
//    'vdig*****ne6',
//    'li??^*^*'
//];
//var arr = [
//    '****************',
//    '****************',
//    '****************',
//    'dDDDddDdDDddDDDDDDDDDdDDD',
//    'dDDDddDdDDddDDDDDDDDDdDDD',
//    'dDDDddDdDDddDDDDDDDDDdDDD',
//    '0o0o0ooOOO0o0o)O0o0o0o0o0o',
//    'o0o0o0o0o0o0o0o0oo0o00Ooo0',
//    'o0o0oOOOOooo0o0o00o0o000ooo',
//    'bBbbbBBbbbBBbbbbBbbBbBbbBBB',
//    'bBbbbBBbbbBBbbbbBbbBbBbbBBB',
//    'bBbbbBBbbbBBbbbbBbbBbBbbBBB',
//    'rRrrrRRRrrRrRRrrRRRRRRrrrRrrrRrr',
//    'rRrrrRRRrrRrRRrrRRRRRRrrrRrrrRrr',
//    'rRrrrRRRrrRrRRrrRRRRRRrrrRrrrRrr',
//    'eEeeEeeEeeEeeEeeeeEEeeEEeeEeeEee',
//    'eEeeEeeEeeEeeEeeeeEEeeEEeeEeeEee',
//    'eEeeEeeEeeEeeEeeeeEEeeEEeeEeeEee',
//    '****************',
//    '****************',
//    '****************',
//    'dDDDddDdDDddDDDDDDDDDdDDD',
//    'dDDDddDdDDddDDDDDDDDDdDDD',
//    'dDDDddDdDDddDDDDDDDDDdDDD',
//    '0o0o0ooOOO0o0o)O0o0o0o0o0o',
//    'o0o0o0o0o0o0o0o0oo0o00Ooo0',
//    'o0o0oOOOOooo0o0o00o0o000ooo',
//    'bBbbbBBbbbBBbbbbBbbBbBbbBBB',
//    'bBbbbBBbbbBBbbbbBbbBbBbbBBB',
//    'bBbbbBBbbbBBbbbbBbbBbBbbBBB',
//    'rRrrrRRRrrRrRRrrRRRRRRrrrRrrrRrr',
//    'rRrrrRRRrrRrRRrrRRRRRRrrrRrrrRrr',
//    'rRrrrRRRrrRrRRrrRRRRRRrrrRrrrRrr',
//    'eEeeEeeEeeEeeEeeeeEEeeEEeeEeeEee',
//    'eEeeEeeEeeEeeEeeeeEEeeEEeeEeeEee',
//    'eEeeEeeEeeEeeEeeeeEEeeEEeeEeeEee',
//    '****************',
//    '****************',
//    '****************',
//    'dDDDddDdDDddDDDDDDDDDdDDD',
//    'dDDDddDdDDddDDDDDDDDDdDDD',
//    'dDDDddDdDDddDDDDDDDDDdDDD',
//    '0o0o0ooOOO0o0o)O0o0o0o0o0o',
//    'o0o0o0o0o0o0o0o0oo0o00Ooo0',
//    'o0o0oOOOOooo0o0o00o0o000ooo',
//    'bBbbbBBbbbBBbbbbBbbBbBbbBBB',
//    'bBbbbBBbbbBBbbbbBbbBbBbbBBB',
//    'bBbbbBBbbbBBbbbbBbbBbBbbBBB',
//    'rRrrrRRRrrRrRRrrRRRRRRrrrRrrrRrr',
//    'rRrrrRRRrrRrRRrrRRRRRRrrrRrrrRrr',
//    'rRrrrRRRrrRrRRrrRRRRRRrrrRrrrRrr',
//    'eEeeEeeEeeEeeEeeeeEEeeEEeeEeeEee',
//    'eEeeEeeEeeEeeEeeeeEEeeEEeeEeeEee',
//    'eEeeEeeEeeEeeEeeeeEEeeEEeeEeeEee',
//    '****************',
//    '****************',
//    '****************',
//    'dDDDddDdDDddDDDDDDDDDdDDD',
//    'dDDDddDdDDddDDDDDDDDDdDDD',
//    'dDDDddDdDDddDDDDDDDDDdDDD',
//    '0o0o0ooOOO0o0o)O0o0o0o0o0o',
//    'o0o0o0o0o0o0o0o0oo0o00Ooo0',
//    'o0o0oOOOOooo0o0o00o0o000ooo',
//    'bBbbbBBbbbBBbbbbBbbBbBbbBBB',
//    'bBbbbBBbbbBBbbbbBbbBbBbbBBB',
//    'bBbbbBBbbbBBbbbbBbbBbBbbBBB',
//    'rRrrrRRRrrRrRRrrRRRRRRrrrRrrrRrr',
//    'rRrrrRRRrrRrRRrrRRRRRRrrrRrrrRrr',
//    'rRrrrRRRrrRrRRrrRRRRRRrrrRrrrRrr',
//    'eEeeEeeEeeEeeEeeeeEEeeEEeeEeeEee',
//    'eEeeEeeEeeEeeEeeeeEEeeEEeeEeeEee',
//    'eEeeEeeEeeEeeEeeeeEEeeEEeeEeeEee',
//    '****************',
//    '****************',
//    '****************',
//    'dDDDddDdDDddDDDDDDDDDdDDD',
//    'dDDDddDdDDddDDDDDDDDDdDDD',
//    'dDDDddDdDDddDDDDDDDDDdDDD',
//    '0o0o0ooOOO0o0o)O0o0o0o0o0o',
//    'o0o0o0o0o0o0o0o0oo0o00Ooo0',
//    'o0o0oOOOOooo0o0o00o0o000ooo',
//    'bBbbbBBbbbBBbbbbBbbBbBbbBBB',
//    'bBbbbBBbbbBBbbbbBbbBbBbbBBB',
//    'bBbbbBBbbbBBbbbbBbbBbBbbBBB',
//    'rRrrrRRRrrRrRRrrRRRRRRrrrRrrrRrr',
//    'rRrrrRRRrrRrRRrrRRRRRRrrrRrrrRrr',
//    'rRrrrRRRrrRrRRrrRRRRRRrrrRrrrRrr',
//    'eEeeEeeEeeEeeEeeeeEEeeEEeeEeeEee',
//    'eEeeEeeEeeEeeEeeeeEEeeEEeeEeeEee',
//    'eEeeEeeEeeEeeEeeeeEEeeEEeeEeeEee'];

//var arr = [
//    'eEeeEeeEeeEeeEeeeeEEeeEEeeEeeEee',
//    'eEeeEeeEeeEeeEeeeeEEeeEEeeEeeEee',
//    'eEeeEeeEeeEeeEeeeeEEeeEEeeEeeEee',
//    '****************',
//    '****************',
//    '****************'
//];

solve(arr);