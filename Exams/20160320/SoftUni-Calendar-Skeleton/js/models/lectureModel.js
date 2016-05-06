var app = app || {};

app.lectureModel = (function () {
    function LectureModel(requester) {
        this._requester = requester;
        this._serviceUrl = requester._baseUrl + 'appdata/' + requester._appId + '/lectures/';
    }

    LectureModel.prototype.getAllLectures = function() {
        //var requestUrl = this._serviceUrl + '?query={"start":"'+deadline + '"}&resolve=_acl.creator';
        var requestUrl = this._serviceUrl;
        return this._requester.get(requestUrl, true);
    };

    LectureModel.prototype.getLecturesByCreatorId = function(userId) {
        var requestUrl = this._serviceUrl + '?query={"_acl.creator":"'+ userId + '"}';
        return this._requester.get(requestUrl, true);
    };

    LectureModel.prototype.addLecture = function(data) {
        return this._requester.post(this._serviceUrl, data, true);
    };

    LectureModel.prototype.editLecture = function(noteId, data) {
        var requestUrl = this._serviceUrl + noteId;
        return this._requester.put(requestUrl, data, true);
    };

    LectureModel.prototype.deleteLecture = function(noteId) {
        var requestUrl = this._serviceUrl + noteId;
        return this._requester.delete(requestUrl, true);
    };

    return {
        load: function (requester) {
            return new LectureModel(requester);
        }
    }
}());