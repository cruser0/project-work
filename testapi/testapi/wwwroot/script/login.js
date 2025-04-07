document.addEventListener("DOMContentLoaded", () => {
    const login = document.getElementById("login");

    login.addEventListener("click", (event) => {
        event.preventDefault();
        redirectToPage();
    });

    function redirectToPage() {
        const name = document.getElementById("email"); 
        const country = document.getElementById("country");

        if (name.value === "" || country.value === "") {
            alert("Country and email can't be empty");
            return;
        }
        
        const url = `http://localhost:5069/paypage.html?name=${encodeURIComponent(name.value)}&country=${encodeURIComponent(country.value)}`;
        
        window.location.href = url;
    }
});
