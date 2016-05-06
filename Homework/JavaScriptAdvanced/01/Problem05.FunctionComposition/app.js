(function () {
    'use strict';
    
    function compose(firstFunc, secFunc) {
        return function () {
            //var arg = secFunc.apply(this, arguments);
            //var rsult = firstFunc(arg);
            //console.log(rsult);
            return firstFunc.call(this, secFunc.apply(this, arguments));
        }
    };
    
    function add(x, y) {
        return x + y;
    }
    function addOne(x) {
        return x + 1;
    }
    function square(x) {
        return x * x;
    }
    
    console.log(compose(addOne, square)(5));
    console.log(compose(addOne, add)(5, 6));
    console.log(compose(Math.cos, addOne)(-1));
    console.log(compose(addOne, Math.cos)(-1));
    var compositeFunction = compose(Math.sqrt, Math.cos);
    console.log(compositeFunction(0.5));
    console.log(compositeFunction(1));
    console.log(compositeFunction(-1));

})();