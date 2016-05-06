function calcCylinderVol(arr) {
    var radius = Number(arr[0]);
    var height = Number(arr[1]);
    var volume = Math.PI * (radius * radius) * height;
    console.log(volume.toFixed(3));
}

var numbs = [2, 4];
calcCylinderVol(numbs);
var numbs = [5, 8];
calcCylinderVol(numbs);
var numbs = [12, 3];
calcCylinderVol(numbs);