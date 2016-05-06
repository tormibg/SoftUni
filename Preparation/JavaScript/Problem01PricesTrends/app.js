function solve(arr) {
    var numbers = [];
    for (var num in arr) {
        numbers.push(Number(parseFloat(arr[num]).toFixed(2)));
    }
    console.log('<table>\r\n<tr><th>Price</th><th>Trend</th></tr>');
    
    console.log('<tr><td>' + numbers[0].toFixed(2) + '</td><td><img src=\"fixed.png\"/></td></td>');
    
    var image = 'fixed';
    
    for (var i = 1; i < numbers.length; i++) {
        if (numbers[i] < numbers[i - 1]) {
            image = 'down';
        } else if (numbers[i] > numbers[i - 1]) {
            image = 'up';
        } else {
            image = 'fixed';
        }
        console.log('<tr><td>' + numbers[i].toFixed(2) + '</td><td><img src=\"' + image + '.png\"/></td></td>');
    }
    
    console.log("</table>");
};

//var arr = ['50', '60'];

var arr = ['36.333', '36.5', '37.019', '35.4', '35', '35.001', '36.225'];

solve(arr);