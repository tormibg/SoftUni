function GetWeekDay(param) {
    var days = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];
    return days[ param.getDay() ];
}

function GetMonthName(param) {
    var months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
    return months[param];
}

Number.prototype.padLeft = function (n, str) {
    return Array(n - String(this).length + 1).join(str || '0') + this;
}

var now = new Date();
var date = now.getUTCDate();
var month = now.getUTCMonth();
var year = now.getUTCFullYear();
var now_utc = new Date(year, month, date, now.getUTCHours(), now.getUTCMinutes(), now.getUTCSeconds());
var space = " ";
var dots = ":";
console.log(now);
console.log(GetWeekDay(now_utc) + ", " + date.padLeft(2, "0") + space + GetMonthName(month) + space + year + space + now.getUTCHours() + dots + now.getUTCMinutes() + dots + now.getUTCSeconds() + space + "GMT");


