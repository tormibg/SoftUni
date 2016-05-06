'use strict';
Object.prototype.getRandom = function () {
    if (this instanceof Array || typeof this === "string") {
        return this[Math.floor(Math.random() * this.length)];
    }
    var keys = Object.keys(this);
    var obj = {};
    var random = Math.random();
    obj[keys[keys.length * random << 0]] = this[keys[keys.length * random << 0]];
    return obj;
};

var arr = [1, 3, 5, 10];
console.log(arr.getRandom());

var str = "This is an example string";
console.log(str.getRandom());

var obj = {
    name: "Gosho",
    age: 25,
    grade: 5.95,
    isActive: true,
    languages: ["English", "French"]
};
console.log(obj.getRandom());
