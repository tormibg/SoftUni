var app = app || {};

app.lectureViewBag = (function () {
    function showLectures(selector, data, menu, myLectures) {
        $.get(menu, function (temp1) {
            $('#menu').html(temp1);
        });
        $.get('templates/calendar.html', function (templ) {
            var rendered = Mustache.render(templ, myLectures);
            $(selector).html(rendered);
            $('#calendar').fullCalendar({
                theme: false,
                header: {
                    left: 'prev,next today addEvent',
                    center: 'title',
                    right: 'month,agendaWeek,agendaDay'
                },
                defaultDate: new Date().toISOString().substr(0, 10),
                selectable: false,
                editable: false,
                eventLimit: true,
                events: data,
                customButtons: {
                    addEvent: {
                        text: 'Add Event',
                        click: function () {
                            $.sammy(function () {
                                this.trigger('redirectUrl', {url: '#/calendar/add/'});
                            });
                        }
                    }
                },
                eventClick: function (calEvent, jsEvent, view) {
                    /*calEvent.start = new Date(Date.parse(calEvent.start)).toISOString().substr(0,10);
                     calEvent.end = new Date(Date.parse(calEvent.end)).toISOString().substr(0,10);*/
                    $.get('templates/modal.html', function (templ) {
                        var rendered = Mustache.render(templ, calEvent);
                        calEvent.start = new Date(Date.parse(calEvent.start)).toISOString().substr(0, 10);
                        calEvent.end = new Date(Date.parse(calEvent.end)).toISOString().substr(0, 10);
                        $('#modal-body').html(rendered);
                        $('#editLecture').on('click', function () {
                            $.sammy(function () {
                                //$('#modal-body').hide();
                                this.trigger('showEditLecture', calEvent);
                            });
                            $('.modal-backdrop').remove();
                        });
                        $('#deleteLecture').on('click', function () {
                            $('.modal-backdrop').remove();
                            $.sammy(function () {
                                this.trigger('showDeleteLecture', calEvent);
                            });
                        });
                    });
                    $('#events-modal').modal();
                }
            });
        })
    }

    function showAddLecture(selector) {
        $.get('templates/add-lecture.html', function (templ) {
            $(selector).html(templ);
            $('#addLecture').on('click', function () {
                var title = $('#title').val(),
                    start = $('#start').val(),
                    end = $('#end').val();

                Sammy(function () {
                    this.trigger('addLecture', {title: title, start: start, end: end});
                })
            })
        })
    }

    function showEditLecture(selector, data) {
        /*data.start = new Date(Date.parse(data.start)).toISOString().substr(0,10)
         data.end = new Date(Date.parse(data.end)).toISOString().substr(0,10)*/
        $.get('templates/edit-lecture.html', function (templ) {
            var rendered = Mustache.render(templ, data);
            $(selector).html(rendered);
            $('#editLecture').on('click', function () {
                var title = $('#title').val(),
                    start = $('#start').val(),
                    end = $('#end').val(),
                    id = data._id;

                Sammy(function () {
                    this.trigger('editLecture', {title: title, start: start, end: end, _id: id});
                })
            })
        })
    }

    function showDeleteLecture(selector, data) {
        $.get('templates/delete-lecture.html', function (templ) {
            var rendered = Mustache.render(templ, data);
            $(selector).html(rendered);
            $('#deleteLecture').on('click', function () {
                var id = data._id;

                Sammy(function () {
                    this.trigger('deleteLecture', {_id: id});
                })
            })
        })
    }

    return {
        load: function () {
            return {
                showLectures: showLectures,
                showAddLecture: showAddLecture,
                showEditLecture: showEditLecture,
                showDeleteLecture: showDeleteLecture
            }
        }
    }
}());