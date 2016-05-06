var models = models || {};

(function (scope) {
    function Item(title, description, price) {
        this.title = title;
        this.description = description;
        this.price = price;
        this._customerReviews = [];
    }

    Item.prototype.addCustomerReview = function addCustomerReview(custReview) {
        this._customerReviews.push(custReview);
    }
    Item.prototype.getCustomerReviews = function getCustomerReviews() {
        return this._customerReviews;
    }

    function UsedItem(title, description, price, condition) {
        Item.apply(this, arguments);
        this.condition = condition;
    }

    UsedItem.prototype = Object.create(Item.prototype);
    UsedItem.prototype.constructor = UsedItem;

    scope.getItem = function (title, description, price) {
        return new Item(title, description, price);
    };

    scope.getUsedItem = function (title, description, price, condition) {
        return new UsedItem(title, description, price, condition);
    };


})(models);