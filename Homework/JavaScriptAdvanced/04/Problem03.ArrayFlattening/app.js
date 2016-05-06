'use strict';

Array.prototype.flatten = function () {
    var arrToReturn = [],
        i;

    for (i = 0; i < this.length; i++) {
        if (Array.isArray(this[i])) {
            arrToReturn = arrToReturn.concat(this[i].flatten());
        } else {
            arrToReturn.push(this[i]);
        }
    }
    return arrToReturn;
};

var array = [1, 2, 3, 4];
console.log(array.flatten());
var array = [1, 2, [3, 4], [5, 6]];
console.log(array.flatten());
console.log(array); // Not changed
var array = [0, ["string", "values"], 5.5, [[1, 2, true], [3, 4, false]], 10];
console.log(array.flatten());
