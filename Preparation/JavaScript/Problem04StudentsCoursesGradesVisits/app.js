function solve(arr) {
    var courses = {};
    
    for (var lineIndex in arr) {
        //var curLine = arr[lineIndex].match(/([a-zA-Z]+\s*[a-zA-Z]+)|([a-zA-Z#]+)|(\d+\.\d+)|(\d+)/g);
        var curLine = arr[lineIndex].trim().split(/\s*\|\s*/);
        var name = curLine[0];
        var course = curLine[1];
        var grade = Number(curLine[2]);
        var visits = Number(curLine[3]);
        
        if (!courses[course]) {
            courses[course] = {
                'avgGrade': 0,
                'avgVisits': 0,
                'students': [],
                'countInput': 0
            };
        }
        courses[course]["avgGrade"] += grade;
        courses[course]["avgVisits"] += visits;
        if (courses[course]["students"].indexOf(name) === -1) {
            courses[course]["students"].push(name);
        }
        courses[course]["countInput"]++;
    }
    var sortedCourses = Object.keys(courses).sort();
    var result = {};

    for (var item in sortedCourses) {
        var currCourse = sortedCourses[item];
        result[currCourse] = courses[currCourse];
        result[currCourse].students.sort();

        result[currCourse].avgGrade = Number((result[currCourse].avgGrade / result[currCourse].countInput).toFixed(2));
        result[currCourse].avgVisits = Number((result[currCourse].avgVisits / result[currCourse].countInput).toFixed(2));
        delete result[currCourse].countInput;
    }

    console.log(JSON.stringify(result));
};

var arr = [
    'Peter Nikolov | PHP  | 5.50 | 8',
    'Maria Ivanova | Java | 5.83 | 7',
    'Ivan Petrov   | PHP  | 3.00 | 2',
    'Ivan Petrov   | C#   | 3.00 | 2',
    'Peter Nikolov | C#   | 5.50 | 8',
    'Maria Ivanova | C#   | 5.83 | 7',
    'Ivan Petrov   | C#   | 4.12 | 5',
    'Ivan Petrov   | PHP  | 3.10 | 2',
    'Peter Nikolov | Java | 6.00 | 9'
];

solve(arr);