var app = app || {};

(function (schoolSystem) {
    function Validator() {

    }

    //OK
    Validator.prototype.validateString = function validateString(string) {
        var pattern = /^[A-Za-z ]+$/g;
        if (!pattern.test(string)) {
            throw new ArgumentException('Letters and spaces only');
        }
    };

    //OK
    Validator.prototype.validateNumber = function validateNumber(number) {
        if (isNaN(number)) {
            throw new Error('Should enter a number');
        }
    };

    //OK
    Validator.prototype.validateConstructorNames = function validateConstructorNames(name, shouldBe) {
        if (name !== shouldBe) {
            throw new Error(shouldBe + ' must be inctance of ' + name)
        }
    };


    //OK
    Validator.prototype.validateSubject = function validateSubject(subject) {
      if (!schoolSystem.Subject.isValidSubject(subject)) {
          throw new Error('Not valid Subject !');
      }
    };

    schoolSystem.validator = new Validator();
})(app);