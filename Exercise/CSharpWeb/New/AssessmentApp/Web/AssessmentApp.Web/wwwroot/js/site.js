// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function CheckImageSize() {
    var errorLabel = document.getElementById("ErrorLabel");
    var submitButton = document.getElementById("submit");
    var files = event.target.files;

    if (files.length === 0) {
        errorLabel.innerHTML = "";
        submitButton.disabled = false;
        return false;
    }
    var size = 0;
    for (var i = 0; i < files.length; i++) {
        var aspFileUpload = files[i];

        var fileName = aspFileUpload.name;
        var ext = fileName.substr(fileName.lastIndexOf('.') + 1).toLowerCase();
        if (!(ext == "jpeg" || ext == "jpg" || ext == "png")) {
            errorLabel.innerHTML = "Invalid image file, must select a *.jpeg, *.jpg, or *.png file.";
            submitButton.disabled = false;
            return false;
        }
        if (aspFileUpload.size == -1) {
            errorLabel.innerHTML = "Couldn't load image file size.  Please try to save again.";
            submitButton.disabled = false;
            return false;
        }
        size = size + aspFileUpload.size;
    }
    if (size <= 18929660) {
        errorLabel.innerHTML = "";
        submitButton.disabled = false;
        return true;
    }
    else {
        var fileSize = (size / 1048576);
        errorLabel.innerHTML = "Файловете са много големи, моля до 18 МБ. Обща големина: " + fileSize.toFixed(1) + " Mb";
        submitButton.disabled = true;
        return false;
    }
};