function solve(arr) {
    var pattern = new RegExp('([^=&?]+)=([^=&?]+)', 'g');
    var spacePattern = new RegExp(/(\+|%20)+/g);
    var lineIndex;
    var curLine;
    
    for (lineIndex in arr) {
        curLine = arr[lineIndex];

        var lineObj = {};

        var match = pattern.exec(curLine);
        while (match) {       
            var key = match[1].replace(spacePattern, ' ').trim();
            var value = match[2].replace(spacePattern, ' ').trim();

            if (!lineObj[key]) {
                //console.log(key);
                lineObj[key] = [];
            }
            lineObj[key].push(value);
            match = pattern.exec(curLine);
        }
        //console.log(lineObj);
        var result = "";
        for (var i in lineObj) {
            //console.log(i);
            result += i + '=[' + lineObj[i].join(', ') + ']';
        }
        console.log(result);
    }
};

//var arr = ['login=student&password=student'];

//var arr = [
//    'field=value1&field=value2&field=value3',
//    'http://example.com/over/there?name=ferret'
//];
var arr = [
    'foo=%20foo&value=+val&foo+=5+%20+203',
    'foo=poo%20&value=valley&dog=wow+',
    'url=https://softuni.bg/trainings/coursesinstances/details/1070',
    'https://softuni.bg/trainings?trainer=nakov&course=oop&course=php'
];

solve(arr);