'use strict';

var Animal = {
    init: function(name, species) {
        this._name = name;
        this._species = species;
    },

    produceSound: function() {
        throw new Error("Cannot call the abstract method Animal.produceSound");
    },
    walk: function() {
        return this._name + " is walking....";
    }
};

var animal = Object.create(Animal);
animal.init("Pesho", "turtle");
console.log(animal.walk());

var Tiger = Object.create(Animal);
Tiger.init = function(name, isSaberToothTiger) {
    Animal.init.call(this, name, "Tiger");
    this._isSaberToothTiger = isSaberToothTiger;
}

var tigger = Object.create(Tiger);
tigger.init("Tigger", false);
tigger.produceSound = function() {
    return "AAAAAAAAAAAAAAAAAAAAAAAAaaaaaaaaaaaaaaaadeafsafsadas";
};
console.log(tigger.produceSound());

tigger.jump = function() {
    return this._name + " is jumping";
}
console.log(tigger.jump());

var normalTiger = Object.create(Tiger);
normalTiger.init("normal tiger", false);
console.log(normalTiger.jump());