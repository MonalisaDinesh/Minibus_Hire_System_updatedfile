
function SigninFunction() {
    var email = document.getElementById('signin_Email').value;
    var password = document.getElementById('signin_Password').value;
    $.ajax({
        type: "POST",
        url: 'SignIn/Signin',
        data: { signin_Email: email, signin_Password: password },
        dataType: "json",
        success: function (response) {
            if (response === false) {
                $('#signInValidation').modal('toggle');
            }
            else {
                //window.location.href = "Home/Index";
                //checkBooking();
                Redirect();
            }
        },
        error: function (ex) {
            $('#signInValidation').modal('toggle');
        }
    });
}

function Redirect() {
    $.ajax({
        type: "GET",
        url: 'Home/checkRedirect',
        dataType: "json",
        success: function (response) {
            if (response === false) {
                window.location.href = "Home/Index";
            }
            else {
                window.location.href = "Home/Booking";
            }
        },
        error: function (ex) {
            $('#signInValidation').modal('toggle');
        }
    });
}

function RegistrationFunction() {
    var model = {
        FirstName: document.getElementById('FirstName').value,
        LastName: document.getElementById('LastName').value,
        Address1: document.getElementById('Address1').values,
        Address2: document.getElementById('Address2').values,
        Address3: document.getElementById('Address3').values,
        City: document.getElementById('City').values,
        County: document.getElementById('County').values,
        Country: document.getElementById('Country').values,
        Email: document.getElementById('Email').values,
        PhoneNumber: document.getElementById('PhoneNumber').values,
        Password: document.getElementById('Password').values,
        ConfirmPassword: document.getElementById('ConfirmPassword').values
    }
    $.ajax({
        type: "POST",
        url: 'SignIn/Registration',
        data: { model: model },
        dataType: "json",
        success: function (response) {
            if (response === false) {
                $('#RegistrationValidation').modal('toggle');
            }
            else {
                alert('Registration Complete Please login.');
                window.location.href = "SignIn/Index";
            }
        },
        error: function (ex) {
            $('#RegistrationValidation').modal('toggle');
        }
    });
}