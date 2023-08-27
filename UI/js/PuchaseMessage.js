//Here we get the data from the local storage to use it as a message
let messageContent = localStorage.getItem('message')
const message = document.querySelector('#txt-message')

if (messageContent == null){
    messageContent = 'Unexpected error! Please check you order history to verify if the product was ordered.'
}

localStorage.clear();
message.textContent = messageContent