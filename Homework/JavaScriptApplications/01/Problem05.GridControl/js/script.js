(function () {
    'use strict'

    function makeRow(elemnts, column) {
        var row = $('<tr></tr>');
        for (var i = 0; i < elemnts.length; i++) {
            $(column).text(elemnts[i]).appendTo(row);
        }
        return row;
    }

    $.fn.grid = function () {
        this.addHeader = function (elements) {
            var row = makeRow(elements, '<th></th>');
            this.find('thead').empty().append(row);

            return this;
        };

        this.addRow = function (elements) {
            var row = makeRow(elements, '<td></td>')
            this.find('tbody').append(row);

            return this;
        }

        return this.empty().append('<thead></thead>').append('<tbody></tbody>');

    }
})();

var grid = $('#myGrid').grid();
grid.addHeader(['First Name', 'Last Name', 'Age']);
grid.addRow(['Bay', 'Ivan', 50]);
grid.addRow(['Kaka', 'Penka', 26]);