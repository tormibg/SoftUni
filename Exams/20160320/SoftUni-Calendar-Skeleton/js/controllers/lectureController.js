var app = app || {};

app.lectureController = (function () {
    function LectureController(viewBag, model) {
        this._model = model;
        this._viewBag = viewBag;
    }

    LectureController.prototype.loadAllLectures = function (selector, menu) {
        var _this = this;
        this._model.getAllLectures()
            .then(function (data) {
                _this._viewBag.showLectures(selector, data, menu, {view: false});
            }, function (error) {
                noty({
                    theme: 'relax',
                    text: error.responseJSON.error || "A problem occurred while trying to get all lectures",
                    type: 'error',
                    timeout: 2000,
                    closeWith: ['click']
                });
            }).done();
    };

    LectureController.prototype.loadMyLectures = function (selector, menu) {
        var _this = this;
        var userId = sessionStorage['userId'];
        this._model.getLecturesByCreatorId(userId)
            .then(function (data) {
                _this._viewBag.showLectures(selector, data, menu, {view: true});
            }, function (error) {
                noty({
                    theme: 'relax',
                    text: error.responseJSON.error || "A problem occurred while trying to get my lectures",
                    type: 'error',
                    timeout: 2000,
                    closeWith: ['click']
                });
            }).done();
    };

    LectureController.prototype.loadAddLecture = function (selector) {
        this._viewBag.showAddLecture(selector);
    };

    LectureController.prototype.addLecture = function (data) {
        var result = {
            title: data.title,
            start: data.start,
            end: data.end,
            lecturer: sessionStorage['username']
        };

        this._model.addLecture(result)
            .then(function (success) {
                noty({
                    theme: 'relax',
                    text: "Successfully added new note!",
                    type: 'success',
                    timeout: 2000,
                    closeWith: ['click']
                });
                $.sammy(function () {
                    this.trigger('redirectUrl', {url: '#/calendar/my/'});
                });

            }, function (error) {
                noty({
                    theme: 'relax',
                    text: error.responseJSON.error || "A problem occurred while trying to add a new lecture",
                    type: 'error',
                    timeout: 2000,
                    closeWith: ['click']
                });
            }).done();
    };

    LectureController.prototype.loadEditLecture = function (selector, data) {
        this._viewBag.showEditLecture(selector, data);
    };

    LectureController.prototype.editLecture = function (data) {
        data.lecturer = sessionStorage['username'];
        this._model.editLecture(data._id, data)
            .then(function (success) {
                noty({
                    theme: 'relax',
                    text: "Successfully edited note!",
                    type: 'success',
                    timeout: 2000,
                    closeWith: ['click']
                });
                $.sammy(function () {
                    this.trigger('redirectUrl', {url: '#/calendar/my/'});
                })
            }, function (error) {
                noty({
                    theme: 'relax',
                    text: error.responseJSON.error || "A problem occurred while trying to edit your lecture",
                    type: 'error',
                    timeout: 2000,
                    closeWith: ['click']
                });
            });
    };

    LectureController.prototype.loadDeleteLecture = function (selector, data) {
        this._viewBag.showDeleteLecture(selector, data);
    };

    LectureController.prototype.deleteLecture = function (noteId) {
        this._model.deleteLecture(noteId)
            .then(function (success) {
                noty({
                    theme: 'relax',
                    text: "Successfully deleted note!",
                    type: 'success',
                    timeout: 2000,
                    closeWith: ['click']
                });
                $.sammy(function () {
                    this.trigger('redirectUrl', {url: '#/calendar/my/'});
                });
            }, function (error) {
                noty({
                    theme: 'relax',
                    text: error.responseJSON.error || "A problem occurred while trying to delete your lecture",
                    type: 'error',
                    timeout: 2000,
                    closeWith: ['click']
                });
            });
    };

    return {
        load: function (viewBag, model) {
            return new LectureController(viewBag, model);
        }
    };
}());