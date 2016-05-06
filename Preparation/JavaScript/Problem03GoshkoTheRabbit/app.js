function solve(arr) {
    var inputDirections = arr[0];
    var directions = inputDirections.split(/,\s/);
    var field = [];
    for (var i = 1; i < arr.length; i++) {
        var row = arr[i].split(/,\s/);
        field.push(row);
    }
    var col = 0, row = 0;
    var visitedCells = [];
    var wallHits = 0;
    var carrots = 0, cabbage = 0, lettuce = 0, turnip = 0;
    
    for (var index in directions) {
        var direction = directions[index];
        var isWallHit = false;

        switch (direction) {
            case 'left':
                col--;
                if (col < 0) {
                    col = 0;
                    isWallHit = true;
                }
                break;
            case 'right':
                col++;
                if (col === field[0].length) {
                    col = field[0].length - 1;
                    isWallHit = true;
                }
                break;
            case 'up':
                row--;
                if (row < 0) {
                    row = 0;
                    isWallHit = true;
                }
                break;
            case 'down':
                row++;
                if (row === field.length) {
                    row = field.length - 1;
                    isWallHit = true;
                }
                break;
            default:
        }
        
        if (isWallHit) {
            wallHits++;
        } else {
            var cell = field[row][col];
            
            while (cell.indexOf('{!}') !== -1) {
                carrots++;
                cell = cell.replace('{!}', '@');
            };
            while (cell.indexOf('{*}') !== -1) {
                cabbage++;
                cell = cell.replace('{*}', '@');
            };
            while (cell.indexOf('{&}') !== -1) {
                lettuce++;
                cell = cell.replace('{&}', '@');
            };
            while (cell.indexOf('{#}') !== -1) {
                turnip++;
                cell = cell.replace('{#}', '@');
            };
            
            visitedCells.push(cell);
        }
    }
    //{"&":0,"*":1,"#":1,"!":0,"wall hits":2}
    var result = '{"&":' + lettuce + ',"*":' + cabbage + ',"#":' + turnip + ',"!":' + carrots + ',"wall hits":' + wallHits + '}';
    console.log(result);
    if (visitedCells.length === 0) {
        console.log("no");
    } else {
        console.log(visitedCells.join("|"));    
    }
}

/*var arr = [
    'right, up, up, down',
    'asdf, as{#}aj{g}dasd, kjldk{}fdffd, jdflk{#}jdfj',
    'tr{X}yrty, zxx{*}zxc, mncvnvcn, popipoip',
    'poiopipo, nmf{X}d{X}ei, mzoijwq, omcxzne'
];*/

var arr = ['up, right, left, down', 'as{!}xnk'];


solve(arr);