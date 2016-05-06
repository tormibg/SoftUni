(function () {
    'use strict ';
    
    var printArgsInfo = function printArgsInfo() {
        var arg, 
            argument, 
            type, 
            value, 
            returnS;

        for (arg in arguments) {
            if (arguments.hasOwnProperty(arg)) {
                argument = arguments[arg];
                type = Array.isArray(argument) ? 'array' : typeof argument;

                if (argument != undefined) {
                    value = argument.valueOf();
                } else {
                    value = argument;
                }
                
                returnS = value + ' (' + type + ')';
                console.log(returnS);
            }
        }
    };
    
    var args = [];
    args = [2, 3, 2.5, -110.5564, false],
    printArgsInfo.call();
    printArgsInfo.call(this, 2, 3, 2.5, -110.5564, false);
    printArgsInfo.apply(this, args);
    args = [null, undefined, "", 0, [], {}];
    printArgsInfo.call(this, null, undefined, "", 0, [], {});
    printArgsInfo.apply(this, args);
    args = [[1, 2], ["string", "array"], ["single value"]];
    printArgsInfo.call(this, [1, 2], ["string", "array"], ["single value"]);
    printArgsInfo.apply(this, args);
    args = ["some string", [1, 2], ["string", "array"], ["mixed", 2, false, "array"], { name: "Peter", age: 20 }];
    printArgsInfo.call(null, "some string", [1, 2], ["string", "array"], ["mixed", 2, false, "array"], { name: "Peter", age: 20 });
    printArgsInfo.apply(null, args);
    args = [[[1, [2, [3, [4, 5]]]], ["string", "array"]]];
    printArgsInfo.call(null, [[1, [2, [3, [4, 5]]]], ["string", "array"]]);
    printArgsInfo.apply(null, args);
})();