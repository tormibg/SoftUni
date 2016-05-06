define([], function () {
    return (function () {
        var id = 0;
        function Actor(name, bio, born) {
            this.name = name;
            this.bio = bio;
            this.born = born;
            this._id = ++id;
        }
        return Actor;
    })();
})