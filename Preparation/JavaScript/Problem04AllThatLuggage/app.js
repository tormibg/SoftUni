function solve(arr) {
    var sorting = arr.pop();
    var result = {};
    for (var lineIndex in arr) {
        var regext = new RegExp(/\.*\*\.*/g);
        var line = arr[lineIndex].split(regext);
        var name = line[0].trim();
        var lugName = line[1].trim();
        var isFood = line[2].trim();
        var isDrink = line[3].trim();
        var isFragie = line[4].trim();
        var weight = parseFloat(line[5]);
        var transferWith = line[6].trim();
        
        var type = 'other';
        if (isFood === 'true') {
            type = 'food';
        } else if (isDrink === 'true') {
            type = 'drink';
        }
        if (!result[name]) {
            result[name] = {};
        };
        
        result[name][lugName] = {
            kg: weight,
            fragile: isFragie === 'true',
            type: type,
            transferredWith: transferWith
        }
    }
    if (sorting === 'strict') {
        //console.log(JSON.stringify(result));
    } else if (sorting === 'luggage name') {
        for (var touristIndex in result) {
            var lugNamesArray = Object.keys(result[touristIndex]);
            lugNamesArray.sort();
            
            var sortedTourist = {};
            for (var l in lugNamesArray) {
                sortedTourist[lugNamesArray[l]] = result[touristIndex][lugNamesArray[l]];
            }
            result[touristIndex] = sortedTourist;
        }
    } else if (sorting === 'weight') {
        for (var tIndex in result) {
            var lugNamesArray = Object.keys(result[tIndex]);
            var lugWeights = [];
            var luggages = [];
            for (var l in lugNamesArray) {
                var curLugg = result[tIndex][lugNamesArray[l]];
                curLugg["name"] = lugNamesArray[l];
                luggages.push(curLugg);
            }
            luggages.sort(function (a, b) {
                return a["kg"] - b["kg"];
            });
            
            var sortedTourist = {};
            for (var l in luggages) {
                
                sortedTourist[luggages[l]["name"]] = {
                    kg: luggages[l].kg,
                    fragile: luggages[l].fragile,
                    type: luggages[l].type,
                    transferredWith: luggages[l].transferredWith
                }
            }
            result[tIndex] = sortedTourist;
        }
    }
    // console.log(result);
    console.log(JSON.stringify(result));
};

//var arr = [
//    'Yana Slavcheva.*.clothes.*.false.*.false.*.false.*.2.2.*.backpack',
//    'Kiko.*.socks.*.false.*.false.*.false.*.0.2.*.backpack',
//    'Kiko.*.banana.*.true.*.false.*.false.*.3.2.*.backpack',
//    'Kiko.*.sticks.*.false.*.false.*.false.*.1.6.*.ATV',
//    'Kiko.*.glasses.*.false.*.false.*.true.*.3.*.ATV',
//    'Manov.*.socks.*.false.*.false.*.false.*.0.3.*.ATV',
//    'strict'
//];

var arr = ['Yana Slavcheva.*.clothes.*.false.*.false.*.false.*.2.2.*.backpack',
    'Kiko.*.socks.*.false.*.false.*.false.*.0.2.*.backpack',
    'Kiko.*.banana.*.true.*.false.*.false.*.3.2.*.backpack',
    'Kiko.*.sticks.*.false.*.false.*.false.*.1.6.*.ATV',
    'Kiko.*.glasses.*.false.*.false.*.true.*.3.*.ATV',
    'Manov.*.socks.*.false.*.false.*.false.*.0.3.*.ATV',
    'weight'
];

solve(arr);