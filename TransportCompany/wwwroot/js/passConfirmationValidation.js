let pass = document.getElementsByClassName('passField')[0];
let passConf = document.getElementsByClassName('confirmPassField')[0];
let acceptBtn = document.getElementsByClassName('acceptBtn')[0];
let form = document.getElementsByClassName('form')[0];

let error = document.getElementsByClassName('error')[0];

function validator() {
    if (pass.value != passConf.value) {
        event.preventDefault();

        error.textContent = 'Пароли не совпадают';
        form.insertBefore(error, confirmPassField.nextSibling);
    }
    else {
        error.textContent = '';
    }
}

form.addEventListener("keyup", validator);
acceptBtn.addEventListener("click", validator);