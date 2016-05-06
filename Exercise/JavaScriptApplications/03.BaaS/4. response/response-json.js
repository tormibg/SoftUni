// Generated by CoffeeScript 1.7.1
(function () {
    var error, getHttpRequest, httpRequest, resourceUrl, success;

    //resourceUrl = 'http://localhost:3000/students';
    resourceUrl = 'https://baas.kinvey.com/appdata/kid_bkkRIQDgyb/students';

    getHttpRequest = (function () {
        var xmlHttpFactories;
        xmlHttpFactories = [
            function () {
                return new XMLHttpRequest();
            }, function () {
                return new ActiveXObject("Msxml3.XMLHTTP");
            }, function () {
                return new ActiveXObject("Msxml2.XMLHTTP.6.0");
            }, function () {
                return new ActiveXObject("Msxml2.XMLHTTP.3.0");
            }, function () {
                return new ActiveXObject("Msxml2.XMLHTTP");
            }, function () {
                return new ActiveXObject("Microsoft.XMLHTTP");
            }
        ];
        return function () {
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

    httpRequest.onreadystatechange = function () {
        if (httpRequest.readyState === 4) {
            switch (Math.floor(httpRequest.status / 100)) {
                case 2:
                    success(JSON.parse(httpRequest.responseText));
                    break;
                default:
                    error(httpRequest.responseText);
            }
        }
    };

    httpRequest.open('GET', resourceUrl, true);
    httpRequest.setRequestHeader('Authorization', 'Basic cGVzaG86MTIzNA==');

    httpRequest.send(null);

    success = function (response) {
        var list, student, students, _i, _len, _ref;
        list = '<ul>';
        if ((response != null) && response.length !== 0) {
            _len = response.length;

            for (i = 0; i < _len; i += 1) {
                student = response[i];
                list += "<li>" + student.name + " is in " + student.grade + " grade</li>";
            }
            list += '</ul>';
            document.getElementById('http-response').innerHTML = list;

        } else {
            document.getElementById('http-response').innerHTML = 'No students available';
        }
    };

    error = function (err) {
        document.getElementById("http-response").innerHTML = "<div><h1 style='color:#f00'>Error happened</h1>" + err + "</div>";
    };

}).call(this);

//# sourceMappingURL=response-json.map