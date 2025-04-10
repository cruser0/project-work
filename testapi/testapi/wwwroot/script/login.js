
document.getElementById('loginForm').addEventListener('submit', async function (e) {
    e.preventDefault(); 
  
    const email = document.getElementById('email').value;
    const password = document.getElementById('password').value;
  
    const payload = {
      email: email,
      password: password,
      isPost: false
    };
  
    try {
      const response = await fetch('http://localhost:5069/api/login-web', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        credentials: 'include', 
        body: JSON.stringify(payload)
      });
  
      if (response.ok) {
        window.location.href = "/paypage";
      } else {
        const errorText = await response.text();
        alert("Login failed: " + errorText);
      }
    } catch (err) {
      alert("Error: " + err.message);
    }
  });
  