function solve(arr) {
    var colorObj = {};
    for (var lineIndex in arr) {
        var lineItems = arr[lineIndex].split(/\|/);
       // console.log(lineItems);
        var color = lineItems[0];
        var colorProp = lineItems[1];
        var propVal = lineItems[2];
        
        if (!colorObj[color]) {
            colorObj[color] = {
                opponents: [],
                wins: 0,
                loss: 0
            };
        }
        
        switch (colorProp) {
            case 'age':
            case 'name':
                colorObj[color][colorProp] = propVal;
                break;
            case 'win':
                colorObj[color].wins++;
                colorObj[color].opponents.push(propVal);
                break;
            case 'loss':
                colorObj[color].loss++;
                colorObj[color].opponents.push(propVal);
                break;
            default:
        }
    }
    var sortesColors = Object.keys(colorObj).sort();
    var newColorObj = {};

    for (var item in sortesColors) {
        if (!colorObj[sortesColors[item]].name || !colorObj[sortesColors[item]].age) {
             continue;
        }
        var rank = ((colorObj[sortesColors[item]].wins + 1) / (colorObj[sortesColors[item]].loss + 1)).toFixed(2);

        newColorObj[sortesColors[item]] = {
            age: colorObj[sortesColors[item]].age, 
            name: colorObj[sortesColors[item]].name,
            opponents: colorObj[sortesColors[item]].opponents.sort(),
            rank: rank
        }
    }
    console.log(JSON.stringify(newColorObj));
};

var arr = [
    'purple|age|99',
    'red|age|44',
    'blue|win|pesho',
    'blue|win|mariya',
    'purple|loss|Kiko',
    'purple|loss|Kiko',
    'purple|loss|Kiko',
    'purple|loss|Yana',
    'purple|loss|Yana',
    'purple|loss|Manov',
    'purple|loss|Manov',
    'red|name|gosho',
    'blue|win|Vladko',
    'purple|loss|Yana',
    'purple|name|VladoKaramfilov',
    'blue|age|21',
    'blue|loss|Pesho'
];

solve(arr);
