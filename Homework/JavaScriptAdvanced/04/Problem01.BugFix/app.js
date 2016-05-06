﻿'use strict';
function Person(firstName, lastName) {
    this._firstName = firstName;
    this._lastName = lastName;
    return {
        name: this._firstName + " " + this._lastName,
        firstName: this._firstName,
        lastName: this._lastName
    };
};

var peter = new Person("Peter", "Jackson");
console.log(peter.name);
console.log(peter.firstName);
console.log(peter.lastName);
console.log(peter);