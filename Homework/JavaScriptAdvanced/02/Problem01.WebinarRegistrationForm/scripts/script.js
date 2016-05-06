'use strict';
// call onload or in script segment below form
function attachCheckboxHandlers() {
    // get reference to element containing toppings checkboxes
    var el = document.getElementById('chk-invoice');

    el.onclick = updateShowHide;
}

// called onclick of toppings checkboxes
function updateShowHide(e) {
    if (this.checked) {
        document.getElementById('data-for-invoice').style.visibility = 'visible';
    } else {
        document.getElementById('data-for-invoice').style.visibility = 'hidden';
    }
}


attachCheckboxHandlers();