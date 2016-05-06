function solve(arr) {
    var bill = Number(arr[0]);
    var state = arr[1];
    var result;
    switch (state) {
        case 'happy':
            {
                result = bill * 0.10;
            }
            break;
        case 'married':
            {
                result = bill * 0.0005;
            }
            break;
        case 'drunk':
            {
                var tip = bill * 0.15;
                var fNum = Number(tip.toString()[0]);
                result = Math.pow(tip,fNum);
            }
            break;
        default:
        {
            result = bill * 0.05;
        }
    }
    console.log(result.toFixed(2));
};

//var arr = ['120.44', 'happy'];
var arr = ['9999.13', 'drunk'];
//var arr = ['716.00', 'borred'];

solve(arr);