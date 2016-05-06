function calculates(param) {
    var newExpression = param.replace(/[^0-9+\-*^%()\/!~&|<>]/g, "");
    document.getElementById("result").value = eval(newExpression);
}