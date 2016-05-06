Object.prototype.extend = function (properties) {
    function f() { };
    f.prototype = Object.create(this);
    for (var prop in properties) {
        f.prototype[prop] = properties[prop];
    }
    f.prototype._super = this;
    return new f();
}

var Vegetable = {
    init: function (name, growthRate) {
        var DEFAULT_GROW_RATE = 1;
        this._name = name;
        this._growthRate = growthRate || 1;
        this._size = 1;
        return this;
    },

    getName: function () {
        return this._name;
    },

    die: function () {
        throw new Error("Vegetable not die");
    },

    grow: function () {
        this._size += this._size * this._growthRate;
    },

    garden: "My garden"
};

var vegetable = Object.create(Vegetable);
vegetable.init("unknow", 1);

var Carrot = Object.create(Vegetable);
Carrot.carrotStuff = "carrotStuff";