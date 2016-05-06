Object.prototype.extends = function (parent) {
    this.prototype = Object.create(parent.prototype);
    this.prototype.constructor = this;
}

var Vegetable = (function () {
    function Vegetable(name, growthRate) {
        var DEFAULT_GROW_RATE = 1;
        if (this.constructor === Vegetable) {
            throw new Error("You can't instantiate abn abstract class.");
        }
        this._name = name;
        this._growthRate = growthRate || 1;
        this._size = 1;
    }

    Vegetable.prototype.getName = function () {
        return this._name;
    }

    Vegetable.prototype.die = function () {
        throw new Error("Vegetable not die");
    }

    Vegetable.prototype.grow = function () {
        this._size += this._size * this.growthRate;
    }

    Vegetable.garden = "My garden";

    return Vegetable;
})();

var Carrot = (function () {
    function Carrot(color) {
        Vegetable.call(this, "carrot", 1.2);
        this._color = color;
        return this;
    }

    Carrot.extends(Vegetable);

    Carrot.prototype.rot = function () {
        this._growthRate = 0;
    }

    Carrot.prototype.die = function () {
        //Vegetable.prototype.die.call(this);
        console.log("I'm dead now");
    }

    return Carrot;
})();

//var vegatable = new Vegetable("Invalid", 500);

var carrot = new Carrot('orange');
carrot.die();