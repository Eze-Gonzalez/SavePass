//Intercambia el tipo de texto para ver u ocultar pass
function togglePassword(repetir = false) {
    if (repetir) {
        var passwordInput = document.getElementById("txtRepetir");
        var checkbox = document.getElementById("chkMostrarRepetir");
        var currentValue = passwordInput.value;

        if (checkbox.checked) {
            passwordInput.setAttribute("type", "text");
        } else {
            passwordInput.setAttribute("type", "password");
        }

        passwordInput.value = currentValue;
    } else {
        var passwordInput = document.getElementById("txtPass");
        var checkbox = document.getElementById("chkMostrarPass");
        var currentValue = passwordInput.value;

        if (checkbox.checked) {
            passwordInput.setAttribute("type", "text");
        } else {
            passwordInput.setAttribute("type", "password");
        }

        passwordInput.value = currentValue;
    }
}

// Fuerza la escritura en mayúsculas
function forzarMayus(event) {
    var charCode = event.which ? event.which : event.keyCode;
    var charLower = String.fromCharCode(charCode);
    var charUpper = charLower.toUpperCase();

    if (charLower !== charUpper) {
        event.target.value += charUpper;
        return false;
    }

    return true;
}

//inhabilita el boton, para que no genere un doble codigo
function disableButton(button) {
    button.style.display = "none";
    var btnCancelar = document.getElementsByClassName("btn-danger");
    for (var i = 0; i < btnCancelar.length; i++) {
        btnCancelar[i].style.display = "none";
    }
    var loader = document.getElementById("loader");
    loader.innerHTML = "";
    loader.className = "loader";
}

function disableButtonR(button) {
    button.style.display = "none";
    var btnCancelar = document.getElementsByClassName("buttonCancelar");
    for (var i = 0; i < btnCancelar.length; i++) {
        btnCancelar[i].style.display = "none";
    }
    var loader = document.getElementById("loader");
    loader.innerHTML = "";
    loader.className = "loader";
}

function loader(button) {
    button.style.display = "none";
    var imgbtn = document.getElementsByClassName("imagen-ver");
    for (var i = 0; i < imgbtn.length; i++) {
        imgbtn[i].style.display = "none";
    }
    var loaderBG = document.getElementById("loaderBG");
    loaderBG.className = "bg-loader"
    var loader = document.getElementById("loader");
    loader.innerHTML = "";
    loader.className = "loader";
}

//Limpia el campo de verificacion para dejarlo vacio
function limpiar() {
    var txtVerificar = document.getElementById("txtVerificar");
    txtVerificar.value = '';
}

//cambia el icono para ocultar o mostrar la contraseña
function mostrarPass(txtPass, icono) {
    var txtPass = document.getElementById(txtPass);
    var icono = document.getElementById(icono);
    if (icono.className === "fa fa-eye-slash") {
        icono.className = "fa fa-eye";
        txtPass.value = txtPass.value;
        txtPass.type = "text";
    }
    else {
        icono.className = "fa fa-eye-slash";
        txtPass.value = txtPass.value;
        txtPass.type = "password";
    }
}

