Number.prototype.padLeft = function (n, str) {
    return Array(n - String(this).length + 1).join(str || '0') + this;
}

function setTime() {
    var now = new Date();
    var currTime = now.getHours().padLeft(2, "0") + ":" + now.getMinutes().padLeft(2, "0") + ":" + now.getSeconds().padLeft(2, "0");
    document.getElementById('clock').textContent = currTime;
}

var clock;
clock = setInterval(setTime, 1000);
