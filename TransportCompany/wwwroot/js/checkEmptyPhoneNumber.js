let phone = document.getElementsByClassName('phone')[0];
let pass = document.getElementsByClassName('pass')[0];
let acceptBtn = document.getElementsByClassName('acceptBtn')[0];
let form = document.getElementsByClassName('form')[0];

let errorPhone = document.getElementsByClassName('errorPhone')[0];
let errorPass = document.getElementsByClassName('errorPass')[0];

function validator() {
    if (phone.value == "") {
        event.preventDefault();

        errorPhone.textContent = 'Поле не может быть пустым';
        form.insertBefore(error, phone.nextSibling);
    }
    else {
        errorPhone.textContent = '';
    }

    if (pass.value == "") {
        event.preventDefault();

        errorPass.textContent = 'Поле не может быть пустым';
        form.insertBefore(error, pass.nextSibling);
    }
    else {
        errorPass.textContent = '';
    }
}

acceptBtn.addEventListener("click", validator);