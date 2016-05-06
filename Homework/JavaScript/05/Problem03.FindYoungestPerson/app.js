'use strict';

function findYoungestPerson(array) {
    var newArray = array.filter(function (person) { return person.hasSmartphone }).sort(function (x, y) { return x.age - y.age })[0];
    var result = "The youngest person is " + newArray.firstname + " " + newArray.lastname;
    return result;
};


var people = [
    { firstname: 'George', lastname: 'Kolev', age: 32, hasSmartphone: false },
    { firstname: 'Vasil', lastname: 'Kovachev', age: 40, hasSmartphone: true },
    { firstname: 'Bay', lastname: 'Ivan', age: 81, hasSmartphone: true },
    { firstname: 'Baba', lastname: 'Ginka', age: 40, hasSmartphone: false }
];

var answer = findYoungestPerson(people);
console.log(answer);