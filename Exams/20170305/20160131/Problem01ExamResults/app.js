function solve(arr) {
    var lastEl = arr.pop().trim();
    var pattern = new RegExp(/\s+/g);
    var students = [];
    var sum = 0;
    var numSums = 0;
    var course;
    for (var lineIndex in arr) {
        var lines = arr[lineIndex].trim().split(pattern);
        var stName = lines[0];
        course = lines[1];
        var examPoints = parseFloat(lines[2]);
        var bonus = parseFloat(lines[3]);
        var coursePoints = (examPoints * 0.2) + bonus;
        var r1 = coursePoints.toFixed(2).replace(/([0-9]+(\.[0-9]+[1-9])?)(\.?0+$)/, '$1');
        //: ((course point / needed points for 6.00(80points)) * 4) + 2
        var grade = ((r1 / 80) * 4) + 2;
        if (grade > 6) {
            grade = 6;
        }
        if (examPoints < 100) {
            console.log(stName+' failed at \"'+course+'\"');
        } else {
            console.log(stName + ': Exam - \"' + course + '\"; Points - ' + r1 + '; Grade - ' + grade.toFixed(2));   
        }
        if (course === lastEl) {
            sum += examPoints;
            numSums++;
        }
    }
    var avgPoints = sum / numSums;
    var r = avgPoints.toFixed(2).replace(/([0-9]+(\.[0-9]+[1-9])?)(\.?0+$)/, '$1');
    console.log('\"'+ lastEl+'\" average points -> '+r);
};

var arr = [
    '      Pesho       C#-Advanced 100 3',
    'Gosho Java-Basics 157         3',
    'Tosho       HTML&CSS 317 12',
    'Minka C#-Advanced          57 15',
    'Stanka C#-Advanced 157 15',
    'Kircho C#-Advanced 300 0',
    'Niki C#-Advanced 400 10',
    'PHP'
];

solve(arr)