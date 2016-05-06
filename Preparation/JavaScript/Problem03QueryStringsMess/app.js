function solve(arr) {
    var pattern = new RegExp('([^=&?]+)=([^=&?]+)', "g");
    var lineIndex;
    
    for (lineIndex in arr) {
        var curLine = arr[lineIndex];
        var lineObj = {};
        
        var match = pattern.exec(curLine);
        while (match) {
            var key = match[1].replace(/(\+|%20)+/g," ").trim();
            var value = match[2].replace(/(\+|%20)+/g, " ").trim();

            if (!lineObj[key]) {
                lineObj[key] = [];
            }
            lineObj[key].push(value);
            match = pattern.exec(curLine);
        }
        var output = '';
        for (var i in lineObj) {
            output += i + '=[' + lineObj[i].join(', ') + ']';
        };
        console.log(output);
    }
};

//var arr = ['login=student&password=student'];
/*var arr = [
    'field=value1&field=value2&field=value3',
    'http://example.com/over/there?name=ferret'
];*/
var arr = [
    'foo=%20foo&value=+val&foo+=5+%20+203',
    'foo=poo%20&value=valley&dog=wow+',
    'url=https://softuni.bg/trainings/coursesinstances/details/1070',
    'https://softuni.bg/trainings?trainer=nakov&course=oop&course=php'
];

solve(arr);