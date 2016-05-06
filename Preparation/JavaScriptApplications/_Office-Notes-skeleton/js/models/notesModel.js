var app = app || {};

app.notesModel = (function () {
    function NotesModel(requester) {
        this.requester = requester;
        this.serviceUrl = this.requester.baseUrl + 'appdata/' + this.requester.appId + '/notes/';
    }

    NotesModel.prototype.getNotesForToday = function (data, showAmount, skipPages) {
        var requestUrl = this.serviceUrl + '?query={"deadline":"' + data.deadline + '"}' +
            '&limit=' + showAmount +
            '&skip=' + skipPages +
            '&count=1';
        return this.requester.get(requestUrl, data, true);
    };

    NotesModel.prototype.getNotesBtyCreatorId = function (data) {
        var requestUrl = this.serviceUrl + '?query={"_acl.creator":"' + data._id + '"}';
        return this.requester.get(requestUrl, data, true);
    };

    NotesModel.prototype.addNote = function (data) {
        return this.requester.post(this.serviceUrl, data, true);
    };

    NotesModel.prototype.editNote = function (data) {
        var serviceUrlforDelete = this.serviceUrl + '/' + data._id;
        return this.requester.put(serviceUrlforDelete, data, true);
    };

    NotesModel.prototype.deleteNote = function (data) {
        var serviceUrlforDelete = this.serviceUrl + '/' + data._id;
        return this.requester.delete(serviceUrlforDelete, data, true);
    };

    return {
        load: function (requester) {
            return new NotesModel(requester);
        }
    }
})();
