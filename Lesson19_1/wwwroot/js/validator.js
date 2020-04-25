function checkForm(form) {
    let desc = document.getElementById('Description').value;
    let name = document.getElementById('Name').value;
    if (desc == "" || name == "") {
        document.getElementById('err_fio').innerHTML = 'Fill in all the input fields!';
        return false;
    };
    return true;
};