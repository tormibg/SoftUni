function GetArea() {
    var myRadius = document.getElementById("radius").value;
    var resultt = 2 * myRadius * Math.PI;
    document.getElementById("result").value = resultt;
}