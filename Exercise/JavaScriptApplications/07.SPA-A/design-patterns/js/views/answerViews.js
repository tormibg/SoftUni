var app = app || {};

app.answerViews = (function() {
    function showAnswers(parent, data) {
        $.get('templates/answers.html', function(templ){
            var outputHtml = Mustache.render(templ, data);
            parent.children().last().html(outputHtml);
        });
    }

    return {
        load: function() {
            return {
                showAnswers: showAnswers
            }
        }
    }
}());