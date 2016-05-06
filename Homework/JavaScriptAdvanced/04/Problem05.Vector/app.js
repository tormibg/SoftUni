'use strict';

var Vector = (function () {
    function Vector(arr) {
        if (!Array.isArray(arr) || !arr || arr.length === 0) {
            throw new Error("Invalid vector !");
        }
        this._arr = arr;
    };
    
    Vector.prototype.toString = function () {
        return "(" + this._arr.join(", ") + ")";
    };
    
    Vector.prototype.add = function (other) {
        var i;
        
        Vector.check(this, other);
        
        var newVector = [];
        for (i = 0; i < this._arr.length; i++) {
            newVector.push(this._arr[i] + other._arr[i]);
        }
        return new Vector(newVector);
    };
    
    Vector.prototype.subtract = function (other) {
        var i,
            newVector = [];
        
        Vector.check(this, other);
        
        for (i = 0; i < this._arr.length; i++) {
            newVector.push(this._arr[i] - other._arr[i]);
        }
        return new Vector(newVector);
    };
    
    Vector.prototype.dot = function (other) {
        var i;
        
        Vector.check(this, other);
        
        var result = 0;
        for (i = 0; i < this._arr.length; i++) {
            result += (this._arr[i] * other._arr[i]);
        }
        return result;
    };
    
    Vector.prototype.norm = function () {
        var result = 0,
            i;
        
        for (i = 0; i < this._arr.length; i++) {
            result += this._arr[i] * this._arr[i];
        }
        return Math.sqrt(result);
    };
    
    Vector.check = function (first, second) {
        if (!(second instanceof Vector)) {
            throw new Error("Not a Vector");
        }
        if (first._arr.length !== second._arr.length) {
            throw new Error("Different size !");
        }
    }
    
    return Vector;
})();

var a = new Vector([1, 2, 3]);
//console.log(a);
var b = new Vector([4, 5, 6]);
var c = new Vector([1, 1, 1, 1, 1, 1, 1, 1, 1, 1]);
console.log(a.toString());
console.log(c.toString());
// The following throw errors
//var wrong = new Vector();
//var anotherWrong = new Vector([]);
var result = a.add(b);
console.log(result.toString());
//a.add(c); // Error
var result = a.subtract(b);
console.log(result.toString());
//a.subtract(c); // Error
var result = a.dot(b);
console.log(result.toString());
//a.dot(c); // Error
console.log(a.norm());
console.log(b.norm());
console.log(c.norm());
console.log(a.add(b).norm());