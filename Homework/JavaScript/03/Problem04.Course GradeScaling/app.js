function courseGradeScaling(input) {
    var str = JSON.parse(JSON.stringify(input));
    
    /*console.log(str);*/

    str.map(function (item) { return item.score = item.score + item.score * 0.1 });

    str.forEach(function (item) { return item.hasPassed = item.score > 100 });
    
    str = str.filter(function (item) { return item.hasPassed });
    
    str.sort(function (x, y) { return x.name.localeCompare(y.name) });
    
    console.log(str);
}
courseGradeScaling([
    {
        'name': 'Пешо',
        'score': 91
    },
    {
        'name': 'Лилия',
        'score': 290
    },
    {
        'name': 'Алекс',
        'score': 343
    },
    {
        'name': 'Габриела',
        'score': 400
    },
    {
        'name': 'Жичка',
        'score': 70
    }
]
);