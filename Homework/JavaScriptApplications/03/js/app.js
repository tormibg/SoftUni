// With a huge help : https://raw.githubusercontent.com/TzvetanIG/JavaScript-App/master/BaaS-and-Parse.com/data-base-functions.js

var app = app || {};

app.requester.config('kid_b1A0IeZGJW', '3e43f860bfde4a5586a1de06c1a97753');

var userRequester = new app.UserRequester();
var collCountries = new app.collectionRequester();


function emptyTable(selector) {
    $(selector + ' tr:not(:first)').remove();
}

function addTownToTable(town) {
    var $table = $('#townList'),
        $tr = $('<tr>'),
        $td = $('<td id="' + town['_id'] + '">'),
        $span = $('<span>').text(town['name']),
        $removeButton = $('<button name="removeTownButton" _id="' + town['_id'] + '">').text('Remove'),
        $editButton = $('<button name="editTownButton" _id="' + town['_id'] + '">').text('Edit');
    $td.append($span).append($removeButton).append($editButton);
    $tr.append($td);
    $table.append($tr);
}

function addCountryToSelect(country) {
    var $option = $('<option value="' + country['_id'] + '">').text(country['name']);
    $('#countries').append($option);
}

function addAllElements(elements, callback) {
    var i;
    for (i = 0; i < elements.length; i++) {
        callback(elements[i]);
    }
}

function addAllCountriesToSelect(countries) {
    $('#countries').children().remove();
    addAllElements(countries, addCountryToSelect);
    showTownsByCountry();
}

function addAllTownsToTable(towns) {
    emptyTable('#townList');
    addAllElements(towns, addTownToTable);
}

function showTownsByCountry() {
    var countryId = $('#countries').val();
    collCountries.getWith('Town', 'country._id', countryId)
        .then(function (success) {
            addAllTownsToTable(success);
        }, function (error) {
        });
}

function saveCountry() {
    var name = $('#countryName').val();
    collCountries.addToCollection('Country', {name: name})
        .then(function (success) {
            update();
        }, function (error) {
        });
    $('#countryName').val('');
}

function deleteCountry() {
    var id = $('#countries').val();
    collCountries.deleteCollection('Country', id, {_id: id})
        .then(function (success) {
            update();
        }, function (error) {
            console.error(error)
        });
    $('#countries').val('');
}

function editCountry() {
    var id = $('#countries').val();
    if ($('#countryName').val()) {
        var name = $('#countryName').val();

        collCountries.editCollection('Country', id, {name: name})
            .then(function (success) {
                update();
            }, function (error) {
                console.error(error)
            });
        $('#countries').val('');
        $('#countryName').val('')
    } else {
        alert('if you want to edit enter a value')
    }
}

function saveTown() {
    var name = $('#townName').val(),
        countryId = $('#countries').val(),
        dataJS = {
            name: name,
            country: {
                "_type": "KinveyRef",
                "_id": countryId,
                "_collection": "Country"
            }
        };

    collCountries.addToCollection('Town', dataJS)
        .then(function (success) {
            update();
        }, function (error) {
        });
    $('#townName').val('');
    $('#countries').val('')
}

function captureClickonTowns(e) {
    var buttonName = $(e.target).attr('name'),
        townId = $(e.target).parent().attr('id');

    switch (buttonName) {
        case 'editTownButton':
            var newTownName = prompt("Please enter new town name", "");
            if (newTownName) {
                var countryId = $('#countries').val(),
                    dataJS = {
                        name: newTownName,
                        country: {
                            "_type": "KinveyRef",
                            "_id": countryId,
                            "_collection": "Country"
                        }
                    };

                collCountries.editCollection('Town', townId, dataJS)
                    .then(function (success) {
                        update();
                    }, function (error) {
                        console.error(error)
                    });

            } else {
                alert('if you want to edit enter a value')
            }
            break;
        case 'removeTownButton':
            collCountries.deleteCollection('Town', townId, {_id: townId})
                .then(function (success) {
                    update();
                }, function (error) {
                    console.error(error)
                });
            break;
    }
}


function update() {
    collCountries.getAll('Country')
        .then(function (success) {
            addAllCountriesToSelect(success)
        }, function (error) {
            console.error(error);
        });
}

userRequester.login('testuser', '1234')
    .then(function (success) {
        update();
    }, function (error) {
        console.error(error);
    });

$('#countries').on('change', showTownsByCountry);
$('#saveCountryButton').on('click', saveCountry);
$('#removeCountryButton').on('click', deleteCountry);
$('#editCountryButton').on('click', editCountry);
$('#saveTownButton').on('click', saveTown);
$('#townList').on('click', captureClickonTowns);


//collCountries.addToCollection('Country',{name:"test"});
//collCountries.addToCollection({"name":"Germany"});
//collCountries.addToCollection({"name":"Greece"});
//collCountries.addToCollection({"name":"Romania"});
//collCountries.addToCollection({"name":"Albania"});