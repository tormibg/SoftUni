if (!Object.create) {
    Object.create = function (proto) {
        function F() { };
        F.prototype = proto;
        return new F();
    };
};

if (!Object.extends) {
    Object.prototype.extends = function (parent) {
        this.prototype = Object.create(parent.prototype);
        this.prototype.constructor = this;
    };
};

var Animal = (function() {
    function Animal(name, species) {
        this._name = name;
        this._species = species;
    }
    
    Animal.prototype.produceSound = function() {
        throw new Error("error !!!");
    }

    Animal.prototype.walk = function() {
        return this._name + " is walking....";
    };

    return Animal;
})();

var animal = new Animal("Pinko", "panther");
animal.walk = function() {
    return "change";
};
console.log(animal.walk());

var Cougar = (function () {

    function Cougar(name, isSaberTooth) {
        Animal.call(this, name, "cougar");
        this._isSaberToothTiger = isSaberTooth;
    }
    
    Cougar.extends(Animal);
    
    Cougar.prototype.walk = function() {
        return Animal.prototype.walk.call(this) + "and is a cougar";
    }
    
    Cougar.prototype.produceSound = function() {
        return "I'LL eat someone";
    }

    return Cougar;
})();

var bigCat = new Cougar("BigCat", false);
console.log(bigCat);
console.log(bigCat.walk());
console.log(bigCat.produceSound());
bigCat.someMethod = function() {
    return "Method called";
}
console.log(bigCat.someMethod());