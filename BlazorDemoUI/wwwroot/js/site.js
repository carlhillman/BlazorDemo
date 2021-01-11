function saveMessage() {
    // var serverValidationsDiv = document.getElementById("serverValidationsDiv");
    //serverValidationsDiv.classList.remove("alert-danger");
    //serverValidationsDiv.classList.add("alert-success");
    //serverValidationsDiv.style.display = "block";
    //serverValidationsDiv.style.opacity = 1;
    //serverValidationsDiv.innerText = firstName + " blev tillagd!";
    fadeOutEffect();
}
function deleteMessage() {
    //var serverValidationsDiv = document.getElementById("serverValidationsDiv");
    //serverValidationsDiv.classList.remove("alert-success");
    //serverValidationsDiv.classList.add("alert-danger");
    //serverValidationsDiv.style.opacity = 1;
    //serverValidationsDiv.style.display = "block";
    //serverValidationsDiv.innerText = "personen togs bort!";
    fadeOutEffect();
}

function fadeOutEffect() {
    //försök ändra till variabel istället 
    var validationDiv = document.getElementById("serverValidationsDiv");
    var fadeEffect = setTimeout(function () {
        if (!document.getElementById("serverValidationsDiv").style.opacity) {
            document.getElementById("serverValidationsDiv").style.opacity = 1;
        }
        if (document.getElementById("serverValidationsDiv").style.opacity > 0) {
            document.getElementById("serverValidationsDiv").style.opacity -= 1;
        } else {
            clearInterval(fadeEffect);
        }
        document.getElementById("serverValidationsDiv").style.display = "none";
    }, 5000);
}


function setTitle(title) {
    document.title = title;
}