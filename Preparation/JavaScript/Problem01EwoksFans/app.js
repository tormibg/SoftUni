function solve(arr) {
    var minDate = new Date(1900, 00, 01);
    var maxDate = new Date(2015, 00, 01);
    var ewoksDate = new Date(1973, 04, 25);
    var haters = false, fans = false;
    var hatersDate = new Date(2015, 00, 01);
    var fansDate = new Date(1973, 04, 25);

    for (var inputLile in arr) {
        var day = Number(arr[inputLile].substr(0, 2));
        var month = Number(arr[inputLile].substr(3, 2)) - 1;
        var year = Number(arr[inputLile].substr(6, 4));
        var newDate = new Date(year, month, day);
        
        if (newDate > minDate && newDate.getTime() !== minDate.getTime() && newDate < maxDate && newDate.getTime() !== maxDate.getTime()) {
            if (newDate < ewoksDate) {
                haters = true;
                if (newDate < hatersDate) {
                    hatersDate = new Date(year, month, day);;
                }
            } else {
                fans = true;
                if (newDate > fansDate) {
                    fansDate = new Date(year, month, day);;
                }
            }
        }
    }
    if (fans) {
        console.log("The biggest fan of ewoks was born on " + fansDate.toDateString());
    }
    if (haters) {
        console.log("The biggest hater of ewoks was born on " + hatersDate.toDateString());
    }
    if (haters === false && fans === false) {
        console.log("No result");
    }
};

//var arr = ['22.03.2014', '17.05.1933', '10.10.1954', '25.05.1973'];
//var arr = ['22.03.2000'];
//var arr = ['22.03.1700', '01.07.2020'];
var arr = ['01.01.1900',
    '01.02.1900',
    '31.12.2014',
    '15.11.2456'];

solve(arr);