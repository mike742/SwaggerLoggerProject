class Validation {

    PriceValidation() {
        const element = document.getElementById('inputPrice') as HTMLInputElement;
        const input: string = element.value;
        const output = document.getElementById('priceValidationMessage');

        if (isNaN(+input)) {
            output.innerHTML = "<span style='color: red'>* Field Price should be Numeric</span>";
        }
        else if (input.length === 0) {
            output.innerHTML = "<span style='color: red'>* Field Price is required</span>";
        }
        else {
            output.innerHTML = '';
        }
    }

    NameValidation() {
        const element = document.getElementById('inputName') as HTMLInputElement;
        const input = element.value;
        const output = document.getElementById('nameValidationMessage');

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
    }

    EmailValidation() {
        const element = document.getElementById('inputEmail') as HTMLInputElement;
        const output = document.getElementById('emailValidationMessage');
        const input = element.value;
        const mailRE = /^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;

        if (!input.match(mailRE)) {
            output.innerHTML = "<span style='color: red'>* You have entered wrong email</span>";
        }
        else {
            output.innerHTML = '';
        }
    }
}

window.onload = () => {

    const obj = new Validation();
    const nameInput = document.getElementById('inputName');
    const priceInput = document.getElementById('inputPrice');
    const emailInput = document.getElementById('inputEmail');

    //document.getElementById('myName').onblur = obj.NameValidation;
    //document.getElementById('myFirstName').onblur = obj.NameValidation;
    //document.getElementById('myFirstName').onblur = obj.NameValidation;
    nameInput.onblur = obj.NameValidation;
    priceInput.onblur = obj.PriceValidation;
    emailInput.onblur = obj.EmailValidation;
}