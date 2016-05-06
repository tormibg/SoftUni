var app = app || {};

app.requester.config('kid_bkkRIQDgyb', '9607743f03ac44c6a0fb42cc217b80fb');

var userRequester = new app.UserRequester();
var questionRequester = new app.collectionRequester('questions');

//userRequester.signUp('Yordan','1234');

userRequester.login('pesho', '1234')
    .then(function (success) {
        questionRequester.getAll()
            .then(function(success){
                var ul = $('<ul>');

                success.forEach(function(question) {
                    $('<li>').text(question.title).appendTo(ul);
                });
                $('#wrapper').append(ul);
            }, function(error){
                console.error(error)
            })
    }, function (error) {
        console.error(error);
    });
//userRequester.getInfo();