var app = app || {};

app.notesViewsBag = (function () {
    function showOfficeNotes(selector, data) {
        $.get('templates/officeNoteTemplate.html', function (templ) {
            var renderedData = Mustache.render(templ, data)
            $(selector).html(renderedData);
            $('#pagination').pagination({
                items: data.pagination.numberOfItems,
                itemsOnPage: data.pagination.itemsPerPage,
                cssStyle: 'light-theme',
                hrefTextPrefix: data.pagination.hrefPrefix
            }).pagination('selectPage', data.pagination.selectedPage);
        }).done();
    }

    function showMyNotes(selector, data) {
        $.get('templates/myNoteTemplate.html', function (templ) {
            var renderedData = Mustache.render(templ, data)
            $(selector).html(renderedData);
            $('.edit').on('click', function () {
                var noteId = $(this).parent().attr('data-id');
                var note = data.notes.filter(function (a) {
                    return a.id == noteId;
                });
                if (note.length) {
                    $.sammy(function () {
                        this.trigger('showEditNote', note[0]);
                    });
                }
            });
            $('.delete').on('click', function () {
                var noteId = $(this).parent().attr('data-id');
                var note = data.notes.filter(function (a) {
                    return a.id == noteId;
                });
                if (note.length) {
                    $.sammy(function () {
                        this.trigger('showDeleteNote', note[0]);
                    });
                }
            });
        })
    }

    function showAddNote(selector) {
        $.get('templates/addNote.html', function (templ) {
            $(selector).html(templ);
            $('#addNoteButton').on('click', function () {
                var title = $('#title').val(),
                    text = $('#text').val(),
                    deadline = $('#deadline').val();

                $.sammy(function () {
                    this.trigger('addNote', {title: title, text: text, deadline: deadline});
                });
            })
        })
    }

    function showEditNote(selector, data) {
        $.get('templates/editNote', function (templ) {
            var renderedData = Mustache.render(templ, data)
            $(selector).html(renderedData);
            $('#editNoteButton').on('click', function () {
                var title = $('#title').val(),
                    text = $('#text').val(),
                    deadline = $('#deadline').val(),
                    id = $(this).parent().attr('data-id');
                $.sammy(function () {
                    this.trigger('editNote', {
                        title: title,
                        text: text,
                        deadline: deadline,
                        id: id
                    });
                });
            });
        })
    }

    function showDeleteNote(selector, data) {
        $.get('templates/deleteNote', function (templ) {
            var renderedData = Mustache.render(templ, data)
            $(selector).html(renderedData);
            $('#deleteNoteButton').on('click', function () {
                var id = $(this).parent().attr('data-id');
                $.sammy(function () {
                    this.trigger('deleteNote', {
                        id: id
                    });
                });
            });
        })
    }

    return {
        load: function () {
            return {
                showOfficeNotes: showOfficeNotes,
                showMyNotes: showMyNotes,
                showAddNote: showAddNote,
                showEditNote: showEditNote,
                showDeleteNote: showDeleteNote
            }
        }
    }
}());