const refreshTokenURI="http://localhost:5069/api/refresh-token-web";

function setCookie(){
    const accessToken = getCookie('accessToken');
    const refreshToken = getCookie('refreshToken');
    console.log("this is refresh "+refreshToken)

    
    if(!refreshToken){
        window.location.replace("http://localhost:5069/login.html");
        return;
    }
    if(!accessToken){
        RefreshToken();

    }

    sessionStorage.setItem("accessToken", accessToken);
    sessionStorage.setItem("refreshToken", refreshToken);

    try {
        const decodedPayload = decodeJwt(accessToken);
        if (!decodedPayload) {
            throw new Error("Invalid token");
        }
        
        const exp = decodedPayload.exp;
        const role = decodedPayload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
        const username = decodedPayload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
        const customerName = decodedPayload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
        const customerCountry = decodedPayload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/country"];
        
        sessionStorage.setItem("exp", exp);
        sessionStorage.setItem("role", role);
        sessionStorage.setItem("username", username);
        sessionStorage.setItem("name", customerName);
        sessionStorage.setItem("country", customerCountry);
    } catch (error) {
        console.error("Error with token:", error);
        window.location.replace("http://localhost:5069/login.html");
    }
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
    
    try {
        const parts = token.split('.');
        if (parts.length !== 3) {
            throw new Error("Invalid token format");
        }
        
        const base64Url = parts[1];
        const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
        const jsonPayload = atob(base64);
        return JSON.parse(jsonPayload);
    } catch (error) {
        console.error("Token decode error:", error);
        return null;
    }
}

function isTokenExpired() {
    const exp = sessionStorage.getItem("exp");
    if (!exp) {
        console.error("Expiration time not found.");
        return true;
    }
    const currentTime = Math.floor(Date.now() / 1000);
    return parseInt(exp) < currentTime;
}

function RefreshToken(){
    fetch(refreshTokenURI, {
        method: 'POST',
        credentials: 'include'
    })
    .then(response => {
        if (!response.ok) {

            throw new Error("Refresh failed");
        }
        return response.json();
    })
    .then(data => {
        setCookie();
    })
    .catch(error => {
        console.error("Error refreshing token:", error);
        window.location.replace("http://localhost:5069/login.html");
    });
}