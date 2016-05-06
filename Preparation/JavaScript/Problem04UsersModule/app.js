function solve(arr) {
    var firstLine = arr[0].replace(/\s+/g, '').split('^');
    var stOrders = firstLine[0];
    var lecOrders = firstLine[1];
    var result = {};
    var role;
    var students = [];
    var trainers = [];
    
    var avr = function (student) {
        var sum = 0;
        for (var j = 0; j < student.length; j++) {
            sum += Number(student[j]);
        }
        return (sum / student.length).toFixed(2);
    };
    var i;
    for (i = 1; i < arr.length; i++) {
        var test = JSON.parse(arr[i]);
        role = test.role;
        if (role === 'student') {
            students.push(test);
        } else {
            trainers.push(test);
        }
    }
    if (stOrders === 'name') {
        students = students.sort(function (a, b) {
            if (a.firstname !== b.firstname) {
                return a.firstname.localeCompare(b.firstname);
            } else {
                return a.lastname.localeCompare(b.lastname);
            }
        });
    };
    if (stOrders === 'level') {
        students = students.sort(function (a, b) {
            if (parseInt(a.level) !== parseInt(b.level)) {
                return parseInt(a.level) - parseInt(b.level);
            } else {
                return parseInt(a.id) - parseInt(b.id);
            }
        });
    };
    
    trainers = trainers.sort(function (a, b) {
        if (a.courses.length !== b.courses.length) {
            return a.courses.length - b.courses.length;
        } else {
            return parseInt(a.lecturesPerDay) - parseInt(b.lecturesPerDay);
        }
    });
    
    var sortedTrainers = [];
    var tmp;
    for (i in trainers) {
        tmp = {
            id: trainers[i].id,
            firstname: trainers[i].firstname,
            lastname: trainers[i].lastname,
            courses: trainers[i].courses,
            lecturesPerDay: trainers[i].lecturesPerDay,
        };
        sortedTrainers.push(tmp);
    }
    
  //  console.log(sortedTrainers);
    
    var sortedStudents = [];
    for (i in students) {
        tmp = {
            id: students[i].id,
            firstname: students[i].firstname,
            lastname: students[i].lastname,
            averageGrade: avr(students[i].grades),
            certificate: students[i].certificate
        };
        sortedStudents.push(tmp);
    }
    result = { "students": sortedStudents, "trainers": sortedTrainers };
    console.log(JSON.stringify(result));

    //    if (!result[role]) {
    //        result[role] = [];
    //    }
    //    delete test.role;
    //    delete test.town;
    //    result[role].push(test);
    //}

    //for (role in result) {
    //    if (role === 'student') {
    //        if (stOrders === 'name') {
    //            result[role] = result[role].sort(function (a, b) {
    //                if (a.firstname !== b.firstname) {
    //                    return a.firstname.localeCompare(b.firstname);
    //                } else {
    //                    return a.lastname.localeCompare(b.lastname);
    //                }
    //            });
    //        } else {
    //            result[role] = result[role].sort(function (a, b) {
    //                if (parseInt(a.level) !== parseInt(b.level)) {
    //                    return parseInt(a.level) - parseInt(b.level);
    //                } else {
    //                    return parseInt(a.id) - parseInt(b.id);
    //                }
    //            });
    //        }
    //    } else {
    //        if (lecOrders === 'courses') {
    //            result[role] = result[role].sort(function(a, b) {
    //                if (a.courses.length !== b.courses.length) {
    //                    return a.courses.length - b.courses.length;
    //                } else {
    //                    return parseInt(a.certLect) - parseInt(b.certLect);
    //                }
    //            });
    //        }
    //    }
    //}
    //for (var role in result) {
    //    delete result[role].level;
    //}
    //console.log(result);
};

//var arr = [
//    'name^courses',
//    '{"id":0,"firstname":"Angel","lastname":"Ivanov","town":"Plovdiv","role":"student","grades":["5.89"],"level":2,"certificate":false}',
//    '{"id":1,"firstname":"Mitko","lastname":"Nakova","town":"Dimitrovgrad","role":"trainer","courses":["PHP","Unity Basics"],"lecturesPerDay":6}',
//    '{"id":2,"firstname":"Bobi","lastname":"Georgiev","town":"Varna","role":"student","grades":["5.59","3.50","4.54","5.05","3.45"],"level":4,"certificate":false}',
//    '{"id":3,"firstname":"Ivan","lastname":"Ivanova","town":"Vidin","role":"trainer","courses":["JS","Java","JS OOP","Database","OOP","C#"],"lecturesPerDay":7}',
//    '{"id":4,"firstname":"Mitko","lastname":"Petrova","town":"Sofia","role":"trainer","courses":["Database","JS Apps","Java"],"lecturesPerDay":2}'
//];

var arr = [
    'name^courses',
    '{"id":0,"firstname":"Angel","lastname":"Ivanov","town":"Plovdiv","role":"student","grades":["5.89"],"level":2,"certificate":false}',
    '{"id":1,"firstname":"Mitko","lastname":"Nakova","town":"Dimitrovgrad","role":"trainer","courses":["PHP","Unity Basics"],"lecturesPerDay":6}',
    '{"id":2,"firstname":"Angel","lastname":"Georgiev","town":"Varna","role":"student","grades":["5.59","3.50","4.54","5.05","3.45"],"level":4,"certificate":false}',
    '{"id":3,"firstname":"Ivan","lastname":"Ivanova","town":"Vidin","role":"trainer","courses":["JS","Java","JS OOP","Database","OOP","C#"],"lecturesPerDay":7}',
    '{"id":4,"firstname":"Mitko","lastname":"Petrova","town":"Sofia","role":"trainer","courses":["Database","JS Apps"],"lecturesPerDay":2}'
];

solve(arr);