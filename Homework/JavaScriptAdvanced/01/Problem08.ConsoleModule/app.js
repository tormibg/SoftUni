(function () {
    'use strict';
    
    var specialConsole = (function () {
        
        var replacePlaceHolders = function (msg, args) {
            var pattern = new RegExp(/{(\d+)}/g),
                match = pattern.exec(msg),
                strToReplace,
                indexOfArgument,
                textForReplaced;
            
            while (match) {
                strToReplace = match[0];
                indexOfArgument = match[1];
                textForReplaced = args[indexOfArgument];
                
                if (textForReplaced == undefined) {
                    textForReplaced = "";
                }
                
                msg = msg.replace(strToReplace, textForReplaced.toString());
                
                match = pattern.exec(msg);
            }
            return msg;
        };
        
        var writeLine = function () {
            var returnMsg = arguments[0];
            Array.prototype.shift.apply(arguments);
            returnMsg = replacePlaceHolders(returnMsg, arguments);
            console.log(returnMsg);
        };
        
        
        return {
            writeLine: writeLine,
            writeError: writeLine,
            writeWarning: writeLine,
            writeInfo: writeLine
        }
    })();
    
    specialConsole.writeLine("Message: hello");
    specialConsole.writeLine("Message: {0}", "hello");
    specialConsole.writeLine("Object: {0}", { name: "Gosho", toString: function () { return this.name } });
    specialConsole.writeError("Error: {0}", "A fatal error has occurred.");
    specialConsole.writeWarning("Warning: {0}", "You are not allowed to do that!");
    specialConsole.writeInfo("Info: {0}", "Hi there! Here is some info for you.");
    specialConsole.writeError("Error object: {0}", { msg: "An error happened", toString: function () { return this.msg } });

})();