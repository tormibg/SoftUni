function solve(arr) {
    var courses = {};
    for (var inputLine in arr) {
        var line = arr[inputLine].trim().replace(/\s+/g, ' ');
        var pattern = new RegExp(/\s*-\s*/g);
        var lines = line.split(pattern);
        var stName = lines[0];
        var pattern1 = new RegExp(/\s*:\s*/g);
        var lines1 = lines[1].split(pattern1);
        var course = lines1[0];
        var examResult = Number(lines1[1]);
        if (examResult >= 0 && examResult <= 400) {
            if (!courses[course]) {
                courses[course] = [];
                courses[course].push({
                    name: stName,
                    result: examResult,
                    makeUpExams: 0
                });
            } else {
                var personFound = courses[course].filter(function (person) {
                    return stName === person.name;
                });
                if (personFound.length !== 0) {
                    personFound[0].makeUpExams += 1;
                    if (examResult > personFound[0].result) {
                        personFound[0].result = examResult;
                    }
                } else {
                    courses[course].push({
                        name: stName,
                        result: examResult,
                        makeUpExams: 0
                    });
                }
            }
        }
    }

    for (var cour in courses) {
        if (courses.hasOwnProperty(cour)) {
            courses[cour] = courses[cour].sort(function(a, b) {
                if (a.result !== b.result) {
                    return b.result - a.result;
                } else {
                    if (a.makeUpExams !== b.makeUpExams) {
                        return a.makeUpExams - b.makeUpExams;
                    } else {
                        return a.name.localeCompare(b.name);
                    }
                }
            });
        }
    }
    console.log(JSON.stringify(courses));
};

//var arr = [
//    'Peter Jackson - Java : 350',
//    'Jane - JavaScript : 200',
//    'Jane     -    JavaScript :     400',
//    'Simon Cowell - PHP : 100',
//    'Simon Cowell-PHP: 500',
//    'Simon Cowell - PHP : 200'
//];

var arr = [
    'Simon Cowell - PHP : 100',
    'Simon Cowell-PHP: 500',
    'Peter Jackson - PHP: 350',
    'Simon Cowell - PHP : 400'
];

solve(arr);
