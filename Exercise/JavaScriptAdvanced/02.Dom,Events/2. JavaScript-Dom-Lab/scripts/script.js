function onClickButtonCalc() {

    var addRow = function() {
        var newRow = document.createElement('tr');
        newRow.id = 'resultRow';
        addCell(newRow);
        addCell(newRow);
        addCell(newRow);
        var target = document.getElementById('thirdRow');
        target.parentNode.insertBefore(newRow, target.nextSibling);
    };
    var sumRows = function (row) {
        var tds;
        if (arguments.length > 1) {
            tds = document.querySelectorAll(row);
        } else {
            tds = document.getElementById(row).querySelectorAll('input');
        }

        var sum = 0;
        for (var i = 0; i < 3; i++) {
            if (tds[i].value.trim() !== "" && !isNaN(Number(tds[i].value))) {
                sum += Number(tds[i].value);
            } else {
                sum = 'Wrong input!';
                break;
            }
        }
        if (arguments.length > 1) {
            var resultTd = document.getElementById('resultRow').querySelectorAll('input');
            resultTd[arguments[1]].value = sum;
        } else {
            tds[3].value = sum;
        }
        
        
    };
    var sumCols = function(col, index) {
        var tds = document.querySelectorAll(col);

    };

    function addCell(element) {
        var newRow = document.createElement('td');
        var newRowInput = document.createElement('input');
        newRowInput.className = 'result';
        newRowInput.type = 'text';
        newRow.appendChild(newRowInput);
        element.appendChild(newRow);
    }
    var items = document.getElementById('firstRow');
    if (items.getElementsByClassName('result').length === 0 ) {
        addCell(items);
        addCell(document.getElementById('secondRow'));
        addCell(document.getElementById('thirdRow'));
    }
    if (document.getElementById('resultRow') === null) {
        addRow();
    }
    document.getElementById('calculate').parentElement.colSpan = 4;

    sumRows('firstRow');
    sumRows('secondRow');
    sumRows('thirdRow');
    sumRows('.firstColumn',0);
    sumRows('.secondColumn', 1);
    sumRows('.thirdColumn', 2);
};