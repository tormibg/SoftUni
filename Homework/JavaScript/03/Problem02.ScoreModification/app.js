function scoreModification(input) {
    /*console.log(input);*/
    var result = input.filter(function (item) { return item >= 0 && item <= 400 })
        .map(function (item) { return item * 0.8 })
        .map(function (item) { return Number(item.toFixed(1)) })
        .sort(function (x, y) { return y < x });
    
    console.log(result);
};
scoreModification([200, 120, 23, 67, 350, 420, 170, 212, 401, 615, -1]);