'use strict';

(function () {
    var htmls = '<!DOCTYPE html><html><head lang="en"><meta charset="UTF-8"><title>index</title><script src="/yourScript.js" defer></script></head><body><div id="outerDiv"><divclass="first"><div><div>hello</div></div></div><div>hi<div></div></div>        <div>I am a div</div></div></body></html>';
    var pattern = new RegExp("(<div)", "g");
    var openDivs = (htmls.match(pattern, htmls) || []).length;
    var closePattern = new RegExp("(<\/div>)", "g");
    var closeDivs = (htmls.match(closePattern, htmls) || []).length;
    if (openDivs === closeDivs) {
        console.log(openDivs);
    } else {
        console.log("Open Divs - " + openDivs + " , close Divs - " + closeDivs);
    }

})();