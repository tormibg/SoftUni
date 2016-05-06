'use strict';
function Person(firstName, lastName) {
    this._firstName = firstName;
    this._lastName = lastName;
    
    Object.defineProperty(this, "lastName", {
        get: function () {
            return this._lastName;
        },
        set: function (lastName) {
            this._lastName = lastName;
        }
    });
    
    Object.defineProperty(this, "firstName", {
        get: function () {
            return this._firstName;
        },
        set: function (firstName) {
            this._firstName = firstName;
        }
    });
    
    Object.defineProperty(this, "fullName", {
        get: function () {
            return this._firstName + ' ' + this._lastName;
        },
        set: function (fullName) {
            var arNames = fullName.split(' ');
            this._firstName = arNames[0];
            this._lastName = arNames[1];
        }
    });
};

var person = new Person("Peter", "Jackson");
console.log(person);
// Getting values
console.log(person.firstName);
console.log(person.lastName);
console.log(person.fullName);
// Changing values
person.firstName = "Michael";
console.log(person.firstName);
console.log(person.fullName);
person.lastName = "Williams";
console.log(person.lastName);
console.log(person.fullName);
// Changing the full name should work too
person.fullName = "Alan Marcus";
console.log(person.fullName);
console.log(person.firstName);
console.log(person.lastName);
