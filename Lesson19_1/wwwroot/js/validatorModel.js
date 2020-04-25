function checkForm(form) {   
    let name = document.getElementById('Name').value;
    if (name == "") {
        document.getElementById('err_fio').innerHTML = 'Fill in all the input fields!';
        return false;
    };
    return true;
};