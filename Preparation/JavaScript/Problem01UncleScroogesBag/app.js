function solve(arr) {
    var totalCoins = 0;
    for (var item in arr) {
        if (arr.hasOwnProperty(item)) {
            var elem = arr[item];
            var parts = elem.split(/\s/);

            if ("coin" === parts[0].toLowerCase()) {
                var coin = parts[1];
                if (coin % 1 === 0 && coin > 0) {
                    totalCoins += parseInt(coin);
                }
            }
        }
    }
    console.log("gold : " + Math.floor(totalCoins / 100));
    console.log("silver : " + Math.floor((totalCoins % 100) / 10));
    console.log("bronze : " + Math.floor(totalCoins % 10));
}

var arr = ['coin 1', 'coin 2', 'coin 5', 'coin 10', 'coin 20', 'coin 50', 'coin 100', 'coin 200', 'coin 500', 'cigars 1'];

solve(arr);