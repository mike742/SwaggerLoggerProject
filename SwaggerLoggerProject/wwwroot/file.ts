class MiValidation {

    MiPriceValidation() {

        let element = document.getElementById('inputMiName');
        // ERRROR is here!!!
        let input = element.value;


        let output = document.getElementById('miPriceValidationMessage');

        if (isNaN(input)) {
            output.innerHTML = "<span style='color: red'>* Field Price should be Numeric</span>";
        }
        else if (input.length === 0) {
            output.innerHTML = "<span style='color: red'>* Field Price is required</span>";
        }
        else {
            output.innerHTML = '';
        }
    }

    miNameValidation(element) {
        let input = element.value;
        let output = document.getElementById('miNameValidationMessage');

        if (input.length === 0) {
            output.innerHTML = "<span style='color: red'>* Field Name is required</span>";
        }
        else {
            output.innerHTML = '';
        }

        console.log(element.value);
    }
}

window.onload = () => {

    let obj = new MiValidation();
    let nameInput = document.getElementById('inputMiName');

    nameInput.onblur = obj.miNameValidation;
}