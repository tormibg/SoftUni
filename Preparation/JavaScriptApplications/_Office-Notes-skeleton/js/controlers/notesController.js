var app = app || {};

app.notesController = (function () {
    function NotesController(model, viewBag, notesPerPage) {
        this._model = model;
        this._viewBag = viewBag;
        this._notesPerPage = notesPerPage;
    }

    NotesController.prototype.loadOfficeNotes = function (selector, page) {
        var _this = this;
        var skipPages = (page - 1) * this._notesPerPage;
        //var date = new Date().toLocaleDateString("en-GB");
        var date = new Date().toISOString().substr(0, 10);
        this._model.getNotesForToday({deadline:date}, this._notesPerPage, skipPages)
            .then(function (data) {
                var result = {
                    notes: [],
                    pagination: {
                        numberOfItems: data.count,
                        itemsPerPage: _this._notesPerPage,
                        selectedPage: page,
                        hrefPrefix: '#/office/'
                    }
                };

                data.forEach(function (note) {
                    result.notes.push({
                        tile: note.title,
                        text: note.text,
                        deadline: note.deadline,
                        author: note.author,
                        id: note._id
                    })
                });
                _this._viewBag.showOfficeNotes(selector, result)
            }).done()
    };

    NotesController.prototype.loadMyNotes = function (selector) {
        var _this = this;
        var userId = sessionStorage['userId'];
        this._model.getNotesBtyCreatorId({_id: userId})
            .then(function (data) {
                var result = {
                    notes: []
                };

                data.forEach(function (note) {
                    result.notes.push({
                        tile: note.title,
                        text: note.text,
                        deadline: note.deadline,
                        author: note.author,
                        id: note._id
                    })
                });
                _this._viewBag.showMyNotes(selector, result)
            }).done()
    };

    NotesController.prototype.loadAddNote = function (selector) {
        this._viewBag.showAddNote(selector);
    };

    NotesController.prototype.addNote = function (data, selector) {
        _this = this;
        var result = {
            title: data.title,
            text: data.text,
            deadline: data.deadline,
            author: sessionStorage['username']
        };
        this._model.addNote(result)
            .then(function (success) {
                noty({
                    theme: 'relax',
                    text: "Successfully added new note!",
                    type: 'success',
                    timeout: 2000,
                    closeWith: ['click']
                });
                _this._viewBag.showMyNotes(selector, data)
            } , function (error) {
                noty({
                    theme: 'relax',
                    text: error.responseJSON.error || "A problem occurred while trying to add a new note",
                    type: 'error',
                    timeout: 2000,
                    closeWith: ['click']
                });
            }).done();
    };

    NotesController.prototype.loadEditNote = function (selector, data) {
        /*var from = data.deadline;
        var temp = from.split("/");
        data.deadline = temp[2] + "-" + temp[1] + "-" + temp[0]*/

        this._viewBag.showEditNote(selector, data);
    };

    NotesController.prototype.editNote = function (data) {
        data.author = sessionStorage['username'];
        this._model.editNote(data)
            .then(function (success) {
                //TODO
            }).done()
    };

    NotesController.prototype.loadDeleteNote = function (selector, data) {
        this._viewBag.showDeleteNote(selector, data);
    };

    NotesController.prototype.deleteNote = function (data) {
        this._model.deleteNote(data)
            .then(function (success) {
                //TODO
            }).done()
    };

    return {
        load: function (model, viewBag, notesPerPage) {
            return new NotesController(model, viewBag, notesPerPage);
        }
    };
}());