'use strict'
function changeBack(){
    var classForChange = '.'+$('.forPaint').val();
    var newColor = '#'+$('#color_value').val();

    $(classForChange).css("background-color", newColor);
}