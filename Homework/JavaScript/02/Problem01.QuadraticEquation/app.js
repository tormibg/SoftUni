function getX1X2() {
    var a = document.getElementById("coefA").value;
    var b = document.getElementById("coefB").value;
    var c = document.getElementById("coefC").value;
    var a2 = 2 * a;
    var ac = 4 * a * c;
    var dis = (b * b) - ac;
    if (dis < 0) {
        document.getElementById("real").innerHTML = "No real roots";
    } else {
        var disSqrt = Math.sqrt(dis);
        var x1 = (-b - disSqrt) / a2;
        var x2 = (-b + disSqrt) / a2;
        var strToWrite;
        if (x1 === x2) {
            strToWrite = "X = " + x1;
        } else {
            strToWrite = "X1 = " + x1 + "<br/> X2 = " + x2;
        };
        document.getElementById("real").innerHTML = strToWrite;
    };
};