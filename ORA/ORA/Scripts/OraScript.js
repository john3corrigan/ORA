function tabActive(btnName) {
    var i, buttonName;

    buttonName = document.getElementsByClassName("dropbtn");
    for (i = 0; i < buttonName.length; i++) {
        buttonName[i].className = buttonName[i].className.replace(" active", "");
    }

    document.getElementById(btnName).className += " active";

}