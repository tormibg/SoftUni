(function () {
    'use strict'
    $(document).ready(function () {

            //assign button click event to call function to create html table dynamically
            $("#btnCreateHtmlTable").click(function () {
                CreateHtmlTable();
            });
        }
    );

    String.prototype.capitalizeFirstLetter = function () {
        return this.charAt(0).toUpperCase() + this.slice(1);
    };

    function CreateHtmlTable() {

        var jsonObj = [{"manufacturer": "BMW", "model": "E92 320i", "year": 2011, "price": 50000, "class": "Family"},
            {"manufacturer": "Porsche", "model": "Panamera", "year": 2012, "price": 100000, "class": "Sport"},
            {"manufacturer": "Peugeot", "model": "305", "year": 1978, "price": 1000, "class": "Family"}]

        //Clear result div
        $("#ResultArea").html("");

        //Crate table html tag
        var table = $("<table id=DynamicTable border=1></table>").appendTo("#ResultArea");

        //Create table header row
        var rowHeader = $("<thead></thead>").empty().appendTo(table);
        $("<tr></tr>").appendTo(table);
        for (var i = 0; i < 1; i++) {
            for (var obj1 in jsonObj[i]) {
                if (jsonObj[i].hasOwnProperty(obj1)) {
                    $("<td></td>").text(obj1.capitalizeFirstLetter()).appendTo(rowHeader);
                }
            }
        }
        for (var obj in jsonObj) {
            if (jsonObj.hasOwnProperty(obj)) {
                var newObj = jsonObj[obj];
                var row = $('<tr></tr>');
                //var elements = [];
                $.each(newObj, function (index, elem) {
                    //elements.push(elem);
                    $('<td></td>').text(elem).appendTo(row);
                });
                //$('<tr><td> ' + elements[0] + ' </td> <td> ' + elements[1] + ' </td><td> ' + elements[2] + ' </td><td> ' + elements[3] + ' </td><td> ' + elements[4] + ' </td></tr>').appendTo(table)
                row.appendTo(table);
            }
        }
    };
})();