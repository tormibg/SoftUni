function solve(arr) {
    
    var star01 = arr[0].trim().split(/\s+/g);
    var star02 = arr[1].trim().split(/\s+/g);
    var star03 = arr[2].trim().split(/\s+/g);
    
    var starN = [star01[0], star02[0], star03[0]];
    var starX = [parseFloat(star01[1]), parseFloat(star02[1]), parseFloat(star03[1])];
    var starY = [parseFloat(star01[2]), parseFloat(star02[2]), parseFloat(star03[2])];
    
    var sCord = arr[3].trim().split(/\s+/g);
    var sX = parseFloat(sCord[0]);
    var sY = parseFloat(sCord[1]);
    
    var nTurns = Number(arr[4]);
    var checkStar = function (x, y, starX1, starY1) {
        return ((x <= starX1 + 1 && x >= starX1 - 1) &&
        (y <= starY1 + 1 && y >= starY1 - 1));
    };
    for (var i = 0; i <= nTurns; i++) {
        var ifOnStar = false;
        for (var j = 0; j < 4; j++) {
            if (checkStar(sX, sY, starX[j], starY[j])) {
                console.log(starN[j].toLowerCase());
                ifOnStar = true;
                break;
            }
        }
        if (!ifOnStar) {
            console.log('space');
        }
        sY++;
    }
};

//var arr = [
//    'Sirius 3 7',
//    'Alpha-Centauri 7 5',
//    'Gamma-Cygni 10 10',
//    '8 1',
//    '6'
//];
var arr = ['Terra-Nova 16 2', 'Perseus 2.6 4.8', 'Virgo 1.6 7', '2 5', '4'];

solve(arr);