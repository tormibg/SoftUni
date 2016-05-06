'use strict';

function clone(obj) {
    var newObj = JSON.parse(JSON.stringify(obj));
    return newObj;
};

function compareObjects(obj, objCopy) {
    var result = "a == b --> " + (obj == objCopy);
    console.log(result);
};

var a = { name: 'Pesho', age: 21 }
var b = clone(a); // a deep copy 
compareObjects(a, b);

var a = { name: 'Pesho', age: 21 };
var b = a; // not a deep copy
compareObjects(a, b);
