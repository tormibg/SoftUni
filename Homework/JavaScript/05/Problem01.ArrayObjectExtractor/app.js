'use strict';

function extractObjects(array) {
    var newArray = [];
    for (var item in array) {
        if (array.hasOwnProperty(item)) {
            // check arrays !!!
            //console.log(Array.isArray(array[item]));
            //console.log(array[item] instanceof Array);
            //console.log(Object.prototype.toString.call(array[item]) === '[object Array]')
            if (typeof array[item] === 'object' && array[item] !== null && Object.prototype.toString.call(array[item]) !== '[object Array]') {
                newArray.push(array[item]);
            };
        };
    };
    return newArray;
};


var array = [
    "Pesho",
    4,
    4.21,
    { name: 'Valyo', age: 16 },
    { type: 'fish', model: 'zlatna ribka' },
    [1, 2, 3],
    "Gosho",
    { name: 'Penka', height: 1.65 }
];

var newArray = extractObjects(array);
console.log(newArray);
