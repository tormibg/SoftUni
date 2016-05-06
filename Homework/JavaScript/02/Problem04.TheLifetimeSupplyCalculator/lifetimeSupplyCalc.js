function calcSupply(age, maxAge, food, foodPerDay) {
    age = Number(age);
    maxAge = Number(maxAge);
    food = String(food);
    foodPerDay = Number(foodPerDay);
    
    var consume = ((maxAge - age) * 365) * foodPerDay;
    var msg = consume + "kg of " + food + " would be enough until I am " + maxAge + " years old.";
    console.log(msg);
}

calcSupply(38, 118, "chocolate", 0.5);
calcSupply(20, 87, "fruits", 2);
calcSupply(16, 102, "nuts", 1.1);