const loginBtn = document.getElementById('loginBtn');
const modal = document.getElementById('loginModal');
const closeBtn = document.querySelector('.close');
const loginForm = document.getElementById('loginForm');
const resultDiv = document.getElementById('result');


loginBtn.onclick = function() {
    modal.style.display = 'block';
}


closeBtn.onclick = function() {
    modal.style.display = 'none';
}


loginForm.onsubmit = function(event) {
    event.preventDefault();
    
    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;


    const validUsername = 'admin';
    const validPassword = '1234';

    if (username === validUsername && password === validPassword) {
        modal.style.display = 'none';
        resultDiv.textContent = 'HOŞ GELDİNİZ';
        resultDiv.style.color = 'green';
    } else {
        modal.style.display = 'none';
        resultDiv.textContent = 'Başarısız İşlem';
        resultDiv.style.color = 'red';
    }
}
window.onclick = function(event) {
    if (event.target == modal) {
        modal.style.display = 'none';
    }
}
