function solve(arr) {
    var pattern = new RegExp(/\d+/g);
    var grad = parseInt(arr[0].match(pattern));
    
    var rotateMatrix90 = function (matrix1) {
        var result = new Array(matrix1[0].length);
        
        for (var col = 0; col <= matrix1[0].length; col++) {
            result[col] = new Array(matrix1.length - 1);
            for (var row = 0; row <= matrix1.length-1; row++) {
                result[col][matrix1.length - 1 - row] = matrix1[row][col];
            }
        }

        return result;

    };
    
    grad = grad % 360;
    var matrix = [];
    var len = 0;
    var i;
    for (i = 1; i < arr.length; i++) {
        var line = arr[i].length;
        matrix.push(arr[i].split(''));
        if (line > len) {
            len = line;
        }
    }
    for (var j = 0; j < matrix.length; j++) {
        while (matrix[j].length < len) {
            matrix[j].push(' ');
        }
    }

    while (grad > 0) {
        matrix = rotateMatrix90(matrix);
        grad -= 90;
    } 
   
    for (i in matrix) {
        console.log(matrix[i].join(''));
    }
};

var arr = ['Rotate(90)', 'hello', 'softuni', 'exam'];
//var arr = ['Rotate(180)', 'hello', 'softuni', 'exam'];
//var arr = ['Rotate(270)', 'hello', 'softuni', 'exam'];
//var arr = ['Rotate(720)', 'js', 'exam'];
//var arr = ['Rotate(810)', 'js', 'exam'];
//var arr = ['Rotate(0)', 'js', 'exam'];

solve(arr);