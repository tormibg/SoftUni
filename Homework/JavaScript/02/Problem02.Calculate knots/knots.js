var readline = require('readline');

var rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

rl.question("Write an numer for km/h to calculate knots: ", function (answer) {
    
    var processed = convert(answer);
    
    console.log("The answer is: ", processed.toFixed(2));
    
    rl.close();
});

function convert(param) {
    var knots = (param / 1.852);
    knots = Math.round(knots * 100) / 100;
    return knots;
}