Function.prototype.call = function (obj) {
    var newArg = [];
    for (var i = 1; i < arguments.length; i++) {
        newArg.push(arguments[i]);
    }
    this.apply(obj, newArg);   
}

function Product(name, price) {
    this.name = name;
    this.price = price;
}

function Food(name,price) {
    Product.call(this, name, price);
   // Product.apply(this, [name, price]);
    this.category = 'food';
}

var cheese = new Food('feta', 5);
console.log(cheese);