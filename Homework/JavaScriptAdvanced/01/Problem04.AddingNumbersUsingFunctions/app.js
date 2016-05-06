(function () {
    'use strict';
    
    var add = function add(n) {
        var f = function (n2) {
            return add(n + n2);
        };
        
        f.valueOf = f.toString = function () { return n };
        
        return f;
    }
    // add + to convert f to number for nodeJS !
    console.log(+add(1));
    console.log(+add(2)(3));
    console.log(+add(1)(1)(1)(1)(1));
    console.log(+add(1)(0)(-1)(-1));
    var addTwo = add(2);
    console.log(+addTwo);
    var addTwo = add(2);
    console.log(+addTwo(3));
    var addTwo = add(2);
    console.log(+addTwo(3)(5));

})(); 