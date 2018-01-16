function solve(arr) {
    var banned = arr.pop().split(' ');
    var ifNotInCode = true;
    //var pattern = new RegExp(/(#[A-Za-z][A-Za-z-_0-9]+)/g);
    var pattern = new RegExp(/(<\/?code>)|(#[A-Za-z][-\w]+)/g);
    for (var lineIndex in arr) {
        var strToReplace = [];
        var strBanned = [];
        var curLine = arr[lineIndex];
        
        var match = pattern.exec(curLine);
        while (match) {
            if (match[1]) {
                var codes = match[1].trim();
                if (codes === '<code>') {
                    ifNotInCode = false;
                } else 
                    {
                    ifNotInCode = true;
                }
            }
            if (ifNotInCode) {
                var regName;
                if (match[2]) {
                    regName = match[2];
                    
                    var lastCh = regName.substring(regName.length - 1, regName.length);
                    if (lastCh.localeCompare('_') !== 0 && lastCh.localeCompare('-') !== 0) {
                        var strForSearch = regName.substring(1, regName.length);
                        if (strForSearch.length >= 3) {
                            if (banned.indexOf(strForSearch) === -1) {
                                strToReplace.push(regName);
                            } else {
                                strBanned.push(regName);
                            }
                        }
                    }
                }
            }
            
            
            match = pattern.exec(curLine);
        }
        
        var i;
        var strForReplace;
        if (strToReplace.length !== 0) {
            for (i in strToReplace) {
                strForReplace = strToReplace[i].substring(1, strToReplace[i].length);
                curLine = curLine.replace(strToReplace[i], '<a href="/users/profile/show/' + strForReplace + '">' + strForReplace + '</a>');
            }
        }
        if (strBanned.length !== 0) {
            for (i in strBanned) {
                strForReplace = "";
                for (var j = 0; j < strBanned[i].length - 1; j++) {
                    strForReplace += '*';
                }
                curLine = curLine.replace(strBanned[i], strForReplace);
            }
        }
        console.log(curLine);
    }
};

var arr = [
    '#as__dasdsa12!@: dsadas #123 I\'m <code> not #Royal sure #as__dasdsa12 what </code> you mean,',
    'pesho gosho'
];

solve(arr);