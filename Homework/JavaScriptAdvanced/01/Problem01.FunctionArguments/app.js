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
    
    printArgsInfo(2, 3, 2.5, -110.5564, false);
    printArgsInfo(null, undefined, "", 0, [], {});
    printArgsInfo([1, 2], ["string", "array"], ["single value"]);
    printArgsInfo("some string", [1, 2], ["string", "array"], ["mixed", 2, false, "array"], { name: "Peter", age: 20 });
    printArgsInfo([[1, [2, [3, [4, 5]]]], ["string", "array"]]);
})();