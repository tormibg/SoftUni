var models = models || {};

(function (scope) {
    function User(username, fullName, balance) {
        this.username = username;
        this.fullName = fullName;
        this._balance = balance;
        this._shopingCart = scope.getShopingCard();
    }

    User.prototype.addItemToCart = function addItemToCard(item) {
        this._shopingCart.addItem(item);
    }

    scope.getUser = function (username, fullName, balance) {
        return new User(username, fullName, balance);
    }
})(models);