function solve(arr) {
    var gold = 0, silver = 0, diamonds = 0;
    arr.forEach(function (str) {
        str = str.trim();
        if (!(str.substring(0, 4).localeCompare('mine'))) {
            var mineData = str.split(/\s+-\s+/)[1];
            if (mineData && mineData.indexOf(':') != -1) {            
                
                var mineType = mineData.split(/\s*:\s*/g)[0].trim();
                var quantity = Number(mineData.split(/\s*:\s*/g)[1].trim());
                
                if (!isNaN(quantity)) {
                    if (!(mineType.toLocaleLowerCase().localeCompare('gold'))) {
                        gold += quantity;
                    } else if (!(mineType.toLocaleLowerCase().localeCompare('silver'))) {
                        silver += quantity;
                    } else if (!(mineType.toLocaleLowerCase().localeCompare('diamonds'))) {
                        diamonds += quantity;
                    }
                }
            }
        }
    });
    console.log('*Silver: ' + silver);
    console.log('*Gold: ' + gold);
    console.log('*Diamonds: ' + diamonds);

};

//var arr = [
//    'mine bobovDol - gold : 10',
//    'mine medenRudnik - silver : 22',
//    'mine chernoMore - shrimps : 24',
//    'gold:50'
//];

var arr = [
    'mine mina - gold - 5',
'mine mina - silver - 5',
'mine mina - diamonds : 5',
'mine mina - gold:5'
];

solve(arr);
