function arrayManupulator(arr) {
    var result = arr.filter(function(item) { return typeof (item) === "number" }).sort(function(x, y) { return x < y });
    var minNumber = Math.min.apply(Math, result);
    var maxNumber = Math.max.apply(Math, result);
    var countObj = {};
    var maxCount = 1;
    var maxElem = result[0];
    for (var num in result) {
        var item = result[num];
        if (countObj[item] == null) {
            countObj[item] = 1;
        } else {
            countObj[item]++;
        };
        if (countObj[item] > maxCount) {
            maxElem = item;
            maxCount = countObj[item];
        };
    };
    var arrStr = "[" + result.join(", ")+"]";
    var str = "Min number: " + minNumber + "\n" + "Max number: " + maxNumber + "\n" + "Most frequent number: " + maxElem + "\n" + arrStr;
    console.log(str);
};

arrayManupulator(["Pesho", 2, "Gosho", 12, 2, "true", 9, undefined, 0, "Penka", { bunniesCount : 10 }, [10, 20, 30, 40]])