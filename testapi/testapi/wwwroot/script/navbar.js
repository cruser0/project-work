window.onload = function() {
    const username = sessionStorage.getItem('username');
    const role = sessionStorage.getItem('role');

    if (username && role) {
        document.getElementById('username').textContent = username;
        document.getElementById('role').textContent = role;
    } else {
        document.getElementById('user-info').innerHTML = '<span class="nav-link">Not logged in</span>';
    }
    const logOutButton=document.getElementById("logout")
    logOutButton.addEventListener("click",()=>window.location.replace("http://localhost:5069/login.html"))
};