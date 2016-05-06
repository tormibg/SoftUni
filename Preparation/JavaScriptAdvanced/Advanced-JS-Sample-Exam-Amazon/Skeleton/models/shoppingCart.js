var models = models || {};

(function (scope) {
    function ShopingCard() {
        this._items = [];
    }

    ShopingCard.prototype.addItem = function addItem(item) {
        this._items.push(item);
    }
    ShopingCard.prototype.getTotalPrice = function getTotalPrice() {
        var totalPrice = 0;
        this._items.forEach(function (item) {
            totalPrice += item.price;
        });
        return totalPrice;
    }

    scope.getShopingCard = function () {
        return new ShopingCard();
    }
})(models);