function solve(arr) {
    Array.prototype.occurs = function (arg) {
        var counter = 0;
        
        for (var i = 0; i < this.length; i++) {
            if (this[i] == arg)
                counter++;
        }
        
        return counter;
    };

    var firstTextWords = [];
    var firstTxt = arr[0];
    var pattern = new RegExp(/[a-zA-z]+/g);

    firstTextWords = firstTxt.toLocaleLowerCase().match(pattern);

    var repeatedWordsObj = {};
    firstTextWords.forEach(function(word) {
        if (firstTextWords.occurs(word) >= 3) {
            repeatedWordsObj[word] = null;
        }
    });
    repeatedWordsObj = Object.keys(repeatedWordsObj);

    if (repeatedWordsObj.length === 0) {
        console.log("No words");
        return;
    }
    var isNoSentence = true;
    //var secondTxt = arr[1].match(/[^\s][\w\s]+[\.\!\?]/g);
    var secondTxt = arr[1].match(/[^\s][^\.\!\?]+[\.\!\?]/g);
    secondTxt.forEach(function (sentence) {
        var secondWords = sentence.match(pattern);
        var count = 0;
        repeatedWordsObj.forEach(function (word) {
            secondWords.forEach(function(word2) {
                if (word === word2.toLowerCase()) {
                    count++;
                    return;
                }
            });
        });
        if (count >= 2) {
            console.log(sentence);
            isNoSentence = false;
        }
    });
    if (isNoSentence) {
        console.log("No sentences");
    }

};

//var arr = [
//    'The words: the and are, are repeated more than three thimes. Look in the second text are there sentences with those words',
//    'Yup there are no such sentences.'
//];

//var arr = [
//    'Why, why is he so crazy, so so crazy? Why?',
//    'There are no words that you should be matching. You should be careful.'
//];

var arr = [
    "Captain Obvious was walking down the street. As the captain was walking a person came and told him: You are Captain Obvious! He replied: Thank you CAPTAIN OBVIOUS you are the man!",
    "The captain was walking and he was obvious. He did not know what was going to happen to you in the future. Was he curious? We do not know."
];

solve(arr);