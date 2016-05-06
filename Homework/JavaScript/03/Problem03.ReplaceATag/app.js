'use strict';

function replaceATag(str) {
    var result = str.replace(/<a/g, "[URL").replace(/>SoftUni<\/a>/g, "]SoftUni[/URL]");
    console.log(result);
};

function replaceATag1(str) {
    var pattern = new RegExp("(<a)(\\s+href=[a-zA-Z:\/.]+)(>)([a-zA-z]+)(</a>)");
    var result = str.replace(pattern, "[URL$2]$4[/URL]");
    console.log(result);

    /*var newValue = "Hey Tricia, how's it going?".replace(
        new RegExp("\\b(Tricia)\\b", "gi"),
        "hottest"
    );
    console.log(newValue);*/
};

replaceATag("<ul><li><a href=http://softuni.bg>SoftUni</a></li></ul>");
replaceATag1("<ul><li><a href=http://softuni.bg>SoftUni</a></li></ul>");