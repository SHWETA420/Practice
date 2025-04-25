
//Login Show Hide Hower
document.addEventListener("DOMContentLoaded", function () {
    console.log("✅ loginpage.js loaded");

    var toggleButton = document.getElementById("togglePassword");
    var passwordField = document.getElementById("password");

    if (toggleButton && passwordField) {
        console.log("✅ Toggle button and password field found");
        toggleButton.addEventListener("click", function () {
            passwordField.type = passwordField.type === "password" ? "text" : "password";
            this.textContent = passwordField.type === "password" ? "Show" : "Hide";
        });
    } else {
        console.error("❌ togglePassword button or password field NOT found");
    }
});

//Signup Alert Function 
function showAlert() {
    alert("User created successfully!");
    return true; // Allows form submission
}
//for api call Signup 

async function submitForm(event) {
    event.preventDefault(); // Prevent default form submission

    console.log("Form Submit Started..."); // Debugging

    var formData = new FormData();
    formData.append("FullName", document.getElementById("FullName").value);
    formData.append("Email", document.getElementById("Email").value);
    formData.append("Password", document.getElementById("Password").value);

    var fileInput = document.getElementById("IdentityImage").files[0];
    if (fileInput) {
        formData.append("IdentityImage", fileInput);
    }

    try {
        let response = await axios.post("https://localhost:7049/api/LoginRegister/SignUpPage", formData, {
            headers: {
                "Content-Type": "multipart/form-data"
            }
        });

        if (response.status === 200) {
            console.log("Success:", response.data);
            let successAlert = document.getElementById("successAlert");
            successAlert.innerText = response.data.message; 
            successAlert.classList.remove("d-none");
            document.getElementById("SignUpPage").reset();
            setTimeout(() => {
                successAlert.classList.add("d-none");
            }, 1000);
        } else {
            console.log("Failed:", response.data);
        }
    } catch (error) {
        console.error("Error submitting form:", error);
    }
}





