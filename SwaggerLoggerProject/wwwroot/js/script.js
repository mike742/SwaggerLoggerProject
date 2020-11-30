var Validation = /** @class */ (function () {
    function Validation() {
    }
    Validation.prototype.PriceValidation = function () {
        var element = document.getElementById('inputPrice');
        var input = element.value;
        var output = document.getElementById('priceValidationMessage');
        if (isNaN(+input)) {
            output.innerHTML = "<span style='color: red'>* Field Price should be Numeric</span>";
        }
        else if (input.length === 0) {
            output.innerHTML = "<span style='color: red'>* Field Price is required</span>";
        }
        else {
            output.innerHTML = '';
        }
    };
    Validation.prototype.NameValidation = function () {
        var element = document.getElementById('inputName');
        var input = element.value;
        var output = document.getElementById('nameValidationMessage');
        if (input.length === 0) {
            output.innerHTML = "<span style='color: red'>* Field Name is required</span>";
        }
        else if (input.length >= 50) {
            output.innerHTML = "<span style='color: red'>* Field Name length should be less than 50</span>";
        }
        else {
            output.innerHTML = '';
        }
        console.log(element.value);
    };
    Validation.prototype.EmailValidation = function () {
        var element = document.getElementById('inputEmail');
        var output = document.getElementById('emailValidationMessage');
        var input = element.value;
        var mailRE = /^([a-zA-Z0-9_\-.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
        if (!input.match(mailRE)) {
            output.innerHTML = "<span style='color: red'>* You have entered wrong email</span>";
        }
        else {
            output.innerHTML = '';
        }
    };
    return Validation;
}());
window.onload = function () {
    var modal = document.getElementById("myModal");
    var modalEdit = document.getElementById("myModalEdit");
    var modalDelete = document.getElementById("myModalDelete");
    var btn = document.getElementById("myBtn");
    var btnEdit = document.getElementById("myBtnEdit");
    var btnDelete = document.getElementById("myBtnDelete");
    var span = document.getElementsByClassName("close")[0];
    var spanCloseEdit = document.getElementById("closeEditMenuItem");
    var spanCloseDelete = document.getElementById("closeDeleteMenuItem");
    btn.onclick = function () {
        modal.style.display = "block";
    };
    btnEdit.onclick = function () {
        modalEdit.style.display = "block";
    };
    btnDelete.onclick = function () {
        modalDelete.style.display = "block";
    };
    span.onclick = function () {
        modal.style.display = "none";
    };
    spanCloseEdit.onclick = function () {
        modalEdit.style.display = "none";
    };
    spanCloseDelete.onclick = function () {
        modalDelete.style.display = "none";
    };
    window.onclick = function (event) {
        if (event.target === modal) {
            modal.style.display = "none";
        }
    };
    var obj = new Validation();
    var nameInput = document.getElementById('inputName'); // undefined
    var priceInput = document.getElementById('inputPrice');
    if (nameInput !== undefined)
        nameInput.onblur = obj.NameValidation;
    if (priceInput !== undefined)
        priceInput.onblur = obj.PriceValidation;
};
//# sourceMappingURL=script.js.map