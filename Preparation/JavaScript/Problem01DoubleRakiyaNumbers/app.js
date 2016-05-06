function solve(arr) {
    var start = parseInt(arr[0]);
    var end = parseInt(arr[1]);
    var i;
    var checkRakiaNumber = function (num1) {
        var numStr = num1.toString();
        var pairs = {};
        for (var j = 1; j < numStr.length; j++) {
            var pair = numStr.substr(j - 1, 2);
            if (pairs[pair]) {
                if (j - pairs[pair] >= 2) {
                    return true;
                }
            } else {
                pairs[pair] = j;
            }
        }
        return false;
    };
    console.log('<ul>');
    
    for (i = start; i <= end; i++) {
        if (checkRakiaNumber(i)) {
            console.log('<li><span class=\'rakiya\'>' + i + '</span><a href=\"view.php?id=' + i + '>View</a></li>');
        } else {
            console.log('<li><span class=\'num\'>' + i + '</span></li>');
        }
    }
    console.log('</ul>');
};

var arr = ['5', '8'];
var arr = ['11210', '11215'];
var arr = ['55555', '55560'];
//var arr = ['111222', '111223'];

solve(arr);