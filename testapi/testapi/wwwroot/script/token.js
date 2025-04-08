
const refreshTokenURI="http://localhost:5069/api/refresh-token-web";
setCookie();


function setCookie(){
    const accessToken = getCookie('accessToken');
    const refreshToken = getCookie('refreshToken');
    sessionStorage.setItem("accessToken",accessToken);
    sessionStorage.setItem("refreshToken",refreshToken);

    const decodedPayload = decodeJwt(accessToken);
    const exp = decodedPayload.exp;
    const role = decodedPayload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
    const username = decodedPayload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
    sessionStorage.setItem("exp",exp);
    sessionStorage.setItem("role",role);
    sessionStorage.setItem("username",username);
}
function getCookie(name) {
    const cookies = document.cookie.split(';');
    for (let cookie of cookies) {
        const [key, value] = cookie.trim().split('=');
        if (key === name) {
            return decodeURIComponent(value);
        }
    }
    return null;
}

function decodeJwt(token) {
    if (!token) {
        console.error("Invalid token.");
        return null; 
    }
    const decodedToken = decodeURIComponent(token);
    const parts = decodedToken.split('.');
    const base64Url = parts[1];
    const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    const jsonPayload = atob(base64);
    return JSON.parse(jsonPayload);
}
function RefreshToken(){
    fetch(refreshTokenURI, {
        method: 'POST',
        credentials: 'include'
    })
    .then(response => response.json())
    .then(data => {
        setCookie();
    })
    .catch(error => {
        console.error("Error creating token:", error);
        window.location.replace("http://localhost:5069/login.html");
    });
}
