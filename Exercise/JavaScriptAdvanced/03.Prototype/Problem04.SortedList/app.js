Array.prototype.sortNum = function () {
    return this.sort(function (a, b) { return a - b });
}

var ListOfNumbers = {
    init: function(arr) {
        this._arr = arr.sortNum();
        this.length = this._arr.length;
    },
    add: function(num) {
        this._arr.push(num);
        this._arr = this._arr.sortNum();
        this.length = this._arr.length;
    },
    get: function(index) {
        return this._arr[index];
    }
};

var arrNumbers = Object.create(ListOfNumbers);
var listArr = [5, 2, 7, 4, 5];
arrNumbers.init(listArr);
console.log(arrNumbers);
arrNumbers.add(10);
console.log(arrNumbers);
console.log(arrNumbers.get(4));
