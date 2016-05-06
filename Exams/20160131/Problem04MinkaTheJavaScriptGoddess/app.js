function solve(arr) {
    var tasksObj = {};
    for (var lineIndex in arr) {
        var curLines = arr[lineIndex].split(/\s+&\s+/g);
        var taskName = curLines[0].trim();
        var taskType = curLines[1].trim();
        var taskNumberName = 'Task ' + parseInt(curLines[2]);
        var taskNumberNum = parseInt(curLines[2]);
        var taskScore = parseFloat(curLines[3]);
        var lineOfCodes = parseInt(curLines[4]);
        
        if (!tasksObj[taskNumberName]) {
            tasksObj[taskNumberName] = {
                tasks: [],
                average: 0,
                lines: 0,
                score: 0,
                allInput: 0

            };
        }
        var tmpObj = {
            name: taskName,
            type: taskType
        };
        tasksObj[taskNumberName].tasks.push(tmpObj);
        tasksObj[taskNumberName].lines += lineOfCodes;
        tasksObj[taskNumberName].score += taskScore;
        tasksObj[taskNumberName].allInput++;

    }
//    console.log(tasksObj);
    var sortedKeys = Object.keys(tasksObj);
    //var test = 'Task 6';
    //console.log(test.length);
    //console.log(test.substring(5,test.length));
    sortedKeys = sortedKeys.sort(function (a, b) {
        //Task 
        return Number(a.substring(5, a.length)) - Number(b.substring(5, b.length));
    });
    var sortedObj = {};
    var j;
    var keyName;
    for (j in sortedKeys) {
        keyName = sortedKeys[j];
        sortedObj[keyName] = tasksObj[keyName];
    }

    for (j in sortedObj) {
        keyName = sortedObj[j];
        var r1 = (parseFloat(keyName.score) / parseFloat(keyName.allInput)).toFixed(2).replace(/([0-9]+(\.[0-9]+[1-9])?)(\.?0+$)/, '$1');
        keyName.average = Number(r1);
        delete keyName.allInput;
        delete keyName.score;
    };
    
    var sortable = []
    for (j in sortedObj) {
        sortable.push([j, sortedObj[j].average, sortedObj[j].lines]);
    }

    sortable.sort(function (a, b) {
        if (Number(b[1]) !== Number(a[1])) {
            return Number(b[1]) - Number(a[1]);
        } else {
            return Number(a[2]) - Number(b[2]);
        }
        
    });
    var sortedObj2 = {};
    for (var j in sortable) {
        keyName = sortable[j][0];
        sortedObj2[keyName] = sortedObj[keyName];
        sortedObj2[keyName].tasks.sort(function(a, b) {
            return a.name.localeCompare(b.name);
        });
    }
    console.log(JSON.stringify(sortedObj2));

};

var arr = [
    'Array Matcher & strings & 4 & 100 & 38',
    'Magic Wand & draw & 3 & 100 & 15',
    'Dream Item & loops & 2 & 88 & 80',
    'Knight Path & bits & 5 & 100 & 65',
    'Basket Battle & conditionals & 2 & 100 & 120',
    'Torrent Pirate & calculations & 1 & 100 & 20',
    'Encrypted Matrix & nested loops & 4 & 90 & 52',
    'Game of bits & bits & 5 & 100 & 18',
    'Fit box in box & conditionals & 1 & 100 & 95',
    'Disk & draw & 3 & 90 & 15',
    'Poker Straight & nested loops & 4 & 40 & 57',
    'Friend Bits & bits & 5 & 100 & 81',
];
solve(arr);