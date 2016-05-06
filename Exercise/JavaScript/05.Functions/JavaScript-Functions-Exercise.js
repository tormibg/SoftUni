function solve(input){
    var n = Number(input[0]),
        stars = n,
        dots = 0,
        i, j, k,
        output = "";
    for (i = 0; i < n / 2; i++) {
        for (j = 0; j < dots; j++) {
            output += ".";
        }
        for (j = 0; j < stars; j++) {
            output += "*";
        }
        for (j = 0; j < dots; j++) {
            output += ".";
        }
        output += "\n";
        stars -= 2;
        dots++;
    }
    dots--;
    stars += 2;
    for (i = 0; i < n / 2 - 1; i++) {
        dots--;
        stars += 2;
        for (j = 0; j < dots; j++) {
            output += ".";
        }
        for (j = 0; j < stars; j++) {
            output += "*";
        }
        for (j = 0; j < dots; j++) {
            output += ".";
        }
        output += "\n"
    }
    return output;
}
console.log(solve(['7']));