(function () {
    require.config({
        paths: {
            'factory': 'helpers/factory',
            'container': 'models/container',
            'item': 'models/item',
            'section': 'models/section'
        }
    });
})();

require(['factory'], function (toDoList) {
    toDoList.AddToDom();
})