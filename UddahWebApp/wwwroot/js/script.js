// script.js - external javascript file for Uddah pages

// sign up form validation, runs when the user clicks Sign Up
function validateSignup() {
    var name = document.forms["signupForm"]["fullname"].value;
    var password = document.forms["signupForm"]["password"].value;
    var confirmPass = document.forms["signupForm"]["confirm"].value;

    if (name == "") {
        window.alert("Please enter your full name");
    }
    else if (password == "") {
        window.alert("Please enter a password");
    }
    else if (password != confirmPass) {
        window.alert("The two passwords do not match");
    }
    else {
        window.alert("Welcome to Uddah, " + name + "!");
    }
}

// login form validation, runs when the user clicks Login
function validateLogin() {
    var email = document.forms["loginForm"]["email"].value;
    var password = document.forms["loginForm"]["password"].value;

    if (email == "") {
        window.alert("Please enter your email");
    }
    else if (password == "") {
        window.alert("Please enter your password");
    }
    else {
        window.alert("Welcome back to Uddah!");
    }
}


// tool preview on the products page: changes the picture and the text
function showTool(number) {
    var picture;   // the new image
    var text;      // the new text

    switch (number) {
        case 1:
            picture = "<img src='/images/impact-drill.jpeg' alt='Cordless impact drill kit' width='150' height='150'>";
            text = "Cordless Impact Drill Kit - 30 SAR / day";
            break;
        case 2:
            picture = "<img src='/images/rotary-hammer.jpeg' alt='Rotary hammer drill' width='150' height='150'>";
            text = "Rotary Hammer Drill - 60 SAR / day";
            break;
        case 3:
            picture = "<img src='/images/tool-set.jpeg' alt='Mechanic and handyman tool set' width='112' height='150'>";
            text = "Mechanic &amp; Handyman Tool Set - 20 SAR / day";
            break;
        case 4:
            picture = "<img src='/images/ladder.jpeg' alt='Aluminum step ladder' width='100' height='150'>";
            text = "Aluminum Step Ladder - 40 SAR / day";
            break;
        default:
            picture = "";
            text = "Tool not found";
    }

    // put the new picture and text in the page
    document.getElementById("toolPicture").innerHTML = picture;
    document.getElementById("toolText").innerHTML = text;
}


// faq on the policy page: shows the answer if it is hidden, and hides it if it is shown
function toggleAnswer(answerId) {
    var answer = document.getElementById(answerId);

    if (answer.style.display == "none") {
        answer.style.display = "block";
    }
    else {
        answer.style.display = "none";
    }
}
// checks the contact form before it is sent (Contact Us page)
function validateContact() {
    var fullName = document.forms["contactForm"]["fullName"].value;
    var email = document.forms["contactForm"]["email"].value;
    var message = document.forms["contactForm"]["message"].value;

    if (fullName == "") {
        window.alert("Please enter your full name.");
        return false;
    }

    if (email == "") {
        window.alert("Please enter your email.");
        return false;
    }

    if (message == "") {
        window.alert("Please write your message.");
        return false;
    }

    window.alert("Thank you " + fullName + ", your message has been sent.");
    return true;
}