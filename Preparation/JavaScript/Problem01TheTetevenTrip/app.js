function solve(arr) {
    for (var lineIndex in arr) {
        var line = arr[lineIndex].split(/\s/);
       // console.log(line);
        var car = line[0];
        var type = line[1];
        var road = line[2];
        var weight = line[3];
        var usedFuel = 10;
        var totalFuel = 0;
        switch (type) {
            case 'diesel':
                usedFuel *= 0.8;
                break;
            case 'gas':
                usedFuel *= 1.2;
                break;
            default :
                usedFuel *= 1;
        }
        usedFuel += weight * 0.01;
        if (road === '1') {
            totalFuel = (110 * usedFuel + usedFuel * 0.3 * 10)/100;
        } else {
            totalFuel = (95 * usedFuel + usedFuel * 0.3 * 30)/100;
        }
        console.log(car + " " + type + " " + road + " " +    Math.round(Number(totalFuel)));
    }
};

var arr = [
    'BMW petrol 1 320.5',
    'Golf petrol 2 150.75',
    'Lada gas 1 202',
    'Mercedes diesel 2 312.54'
];

solve(arr);
