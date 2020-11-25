var MiValidation = /** @class */ (function () {
    function MiValidation() {
    }
    MiValidation.prototype.MiPriceValidation = function (element) {
        var input = element.value;
        var output = document.getElementById('miPriceValidationMessage');
        if (isNaN(input)) {
            output.innerHTML = "<span style='color: red'>* Field Price should be Numeric</span>";
        }
        else if (input.length === 0) {
            output.innerHTML = "<span style='color: red'>* Field Price is required</span>";
        }
        else {
            output.innerHTML = '';
        }
    };
    MiValidation.prototype.miNameValidation = function (element) {
        var input = element.value;
        var output = document.getElementById('miNameValidationMessage');
        if (input.length === 0) {
            output.innerHTML = "<span style='color: red'>* Field Name is required</span>";
        }
        else {
            output.innerHTML = '';
        }
        console.log(element.value);
    };
    return MiValidation;
}());
window.onload = function () {
    var obj = new MiValidation();
    var nameInput = document.getElementById('inputMiName');
    nameInput.onblur = obj.miNameValidation;
};
//# sourceMappingURL=script.js.map