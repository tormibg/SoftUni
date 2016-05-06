/* В условието на задачата /doxs файла/ входа не отоговаря на посочения изход ! */

"use strict";
function groupBy(criteria) {
    
    function Person(firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }
    
    var people = [
        new Person("Scott", "Guthrie", 38),
        new Person("Scott", "Johns", 36),
        new Person("Scott", "Hanselman", 39),
        new Person("Jesse", "Liberty", 57),
        new Person("Jon", "Skeet", 38)
    ];
    
    //console.log(Object.keys(people));
    
    var newPeople = {};
    var item;
    for (item in people) {
        if (people.hasOwnProperty(item)) {
            var groupCriteria = "Group " + people[item][criteria];
            if (newPeople[groupCriteria] == undefined) {
                newPeople[groupCriteria] = [];
            }
            var itemToPush = people[item].firstName.toString() + " " + people[item].lastName.toString() + " " + "(age " + people[item].age.toString() + ")";
            newPeople[groupCriteria].push(itemToPush);
        };
    };
    
    //console.log(newPeople);
    var result = [];
    
    for (item in newPeople) {
        if (newPeople.hasOwnProperty(item)) {
            var value;
            var key;
            if (newPeople.hasOwnProperty(item)) {
                key = item;
                value = newPeople[item].join(", ");
            };
            result[key] = value;
        };
    };
    console.log(result);
}

groupBy('firstName');
groupBy('age');
groupBy('lastName')