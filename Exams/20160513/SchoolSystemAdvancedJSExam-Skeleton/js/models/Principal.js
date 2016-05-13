var app = app || {};

(function (schoolSystem) {
    function Principal(name) {
        schoolSystem._Human.call(this, name);

    }
    Principal.extends(schoolSystem._Human);


    schoolSystem.Principal = Principal;
}(app));