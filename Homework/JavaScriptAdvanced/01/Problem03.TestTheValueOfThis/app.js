(function () {
    'use strict';
    
    function testContext() {
        console.log(this);
    }
    // print global this . in browsers this is gobal object window
    testContext();
    

    function funct2() {
        function f3() {
            testContext();
        }

        f3();
    }
    
    // print global this . in browsers this is gobal object window
    funct2();
    
    
    //print a new object reference - testContext {};
    new testContext();

})();