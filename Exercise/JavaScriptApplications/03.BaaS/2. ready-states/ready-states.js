(function() {
    var appendText, getHttpRequest, httpRequest, resourceUrl;

    resourceUrl = 'https://baas.kinvey.com/appdata/kid_bkkRIQDgyb/questions';

    appendText = function(selector, text) {
        var element;
        element = document.querySelector(selector);
        return element.innerHTML += "<div>" + text + "</div>";
    };

    getHttpRequest = (function() {
        var xmlHttpFactories;
        xmlHttpFactories = [
            function() {
                return new XMLHttpRequest();
            }, function() {
                return new ActiveXObject("Msxml3.XMLHTTP");
            }, function() {
                return new ActiveXObject("Msxml2.XMLHTTP.6.0");
            }, function() {
                return new ActiveXObject("Msxml2.XMLHTTP.3.0");
            }, function() {
                return new ActiveXObject("Msxml2.XMLHTTP");
            }, function() {
                return new ActiveXObject("Microsoft.XMLHTTP");
            }
        ];
        return function() {
            var xmlFactory, _i, _len;
            for (_i = 0, _len = xmlHttpFactories.length; _i < _len; _i++) {
                xmlFactory = xmlHttpFactories[_i];
                try {
                    return xmlFactory();
                } catch (_error) {

                }
            }
            return null;
        };
    })();

    httpRequest = getHttpRequest();

    httpRequest.onreadystatechange = function() {
        switch (httpRequest.readyState) {
            case 1:
                appendText("#http-response", "request in loading state");
                break;
            case 2:
                appendText("#http-response", "request in loaded state");
                break;
            case 3:
                appendText("#http-response", "request in interactive state");
                break;
            case 4:
                appendText("#http-response", "request in complete state");
                break;
            default:
                appendText("#http-response', 'Something else happened, readyState: " + httpRequest.readyState);
        }
    };


    httpRequest.open('GET', resourceUrl, true);

    httpRequest.setRequestHeader('Authorization','Basic cGVzaG86MTIzNA==');
    //httpRequest.setRequestHeader('X-Parse-REST-API-Key', 'NJTYQ5aNKeG3MjHsLkoS8Yl4odmqtHta0aAoO7q8');

    httpRequest.send(null);
}());