function solve(arr) {
    var result = [];
    
    for (var index in arr) {
        arr[index] = arr[index].replace('vs.', ' vs. ');
        arr[index] = arr[index].replace(':', ' : ');
        arr[index] = arr[index].replace(/\s\s+/g, ' ');
        //console.log(arr[index]);
        var newArr = arr[index].split(/\s/);
        
        var player1Name = newArr[0] + " " + newArr[1];
        var player2Name = newArr[3] + " " + newArr[4];
        
        var player1 = null, player2 = null;
        
        for (var item in result) {
            if (result[item].name === player1Name) {
                player1 = result[item];
            }
            if (result[item].name === player2Name) {
                player2 = result[item];
            }
        }
        
        if (player1 === null) {
            player1 = createPlayerObj(player1Name);
            result.push(player1);
          //  console.log(player1);
        }
        if (player2 === null) {
            player2 = createPlayerObj(player2Name);
            result.push(player2);
           // console.log(player2);
        }
        var player1Sets = 0, player2Sets = 0;
        
        for (var i = 6; i < newArr.length; i++) {
            
            var gameArr = newArr[i].split('-');
            //console.log(gameArr);
            var points1 = Number(gameArr[0]);
            var points2 = Number(gameArr[1]);
            
            if (points1 > points2) {
                player1Sets++;
                player1.setsWon++;
                player2.setsLost++;
            } else {
                player2Sets++;
                player1.setsLost++;
                player2.setsWon++;
            }
            
            player1.gamesWon += points1;
            player2.gamesLost += points1;
            player1.gamesLost += points2;
            player2.gamesWon += points2;
        };
        
        if (player1Sets > player2Sets) {
            player1.matchesWon++;
            player2.matchesLost++;
        } else {
            player1.matchesLost++;
            player2.matchesWon++;
        };
    }
    
    result.sort(function (a, b) {
        if (a.matchesWon === b.matchesWon) {
            if (a.setsWon === b.setsWon) {
                var aRatio = 1;
                var bRatio = 1;
                if (a.matchesLost !== 0) {
                    aRatio = a.matchesWon / a.matchesLost;
                }
                if (b.matchesLost !== 0) {
                    bRatio = b.matchesWon / b.matchesLost;
                }
                if (aRatio === bRatio) {
                    if (a.gamesWon === b.gamesWon) {
                        return a.name.localeCompare(b.name);
                    }
                    return b.gamesWon - a.gamesWon;
                    
                }
                return bRatio - aRatio;
                
            }
            return b.setsWon - a.setsWon;
        }
        return b.matchesWon - a.matchesWon;
    });
    
    console.log(JSON.stringify(result));
    
    function createPlayerObj(name) {
        return {
            name: name,
            matchesWon: 0,
            matchesLost: 0,
            setsWon: 0,
            setsLost: 0,
            gamesWon: 0,
            gamesLost: 0
        };
    };
};

var arr = [
    'Novak Djokovic vs. Roger Federer : 6-3 6-3',
    'Roger    Federer    vs.        Novak Djokovic    :         6-2 6-3',
    'Rafael Nadal vs. Andy Murray : 4-6 6-2 5-7',
    'Andy Murray vs. David Ferrer : 6-4 7-6',
    'Tomas Bedrych vs. Kei Nishikori : 4-6 6-4 6-3 4-6 5-7',
    'Grigor Dimitrov vs. Milos Raonic : 6-3 4-6 7-6 6-2',
    'Pete Sampras vs. Andre Agassi : 2-1',
    'Boris Beckervs.Andre        \t\t\tAgassi:2-1'
];

solve(arr);