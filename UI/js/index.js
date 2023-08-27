//Interaction with the API to get the product information
async function getProducts(){
    const API_Service = 'https://products-task-api.azurewebsites.net/api/Product/RetrieveAll'
    fetch(API_Service)
    .then(response => {
        if (!response.ok) {
            throw new Error('Error in the request: ${response.status}');
        }
        return response.json();
    })
    .then(data => {
        includeProductInformation(data[3].productName, data[3].productCode, data[3].price, data[3].description)
    })
    .catch(error => {
        console.error('Error: ', error);
    });    
};

const includeProductInformation = (nameP, codeP, priceP, descriptionP) =>{
    const productName = document.querySelector('#product-name');
    const productCode = document.querySelector('#product-code');
    const description = document.querySelector('#description');
    const price = document.querySelector('#price');

    productName.textContent = nameP
    productCode.textContent = codeP
    description.textContent = 'Price: $' + priceP + '.00'
    price.textContent = descriptionP
};

getProducts();

//Here we can control the gallery 
const showImage = (smallImg) => {
    const fullImg = document.querySelector('#imageBox')
    fullImg.src = smallImg.src;
}

//function to send a POST request to the API to buy a product
async function buyNow() {
    const API_Service = 'https://products-task-api.azurewebsites.net/api/Product/Buy';
    
    console.log(document.querySelector('#product-name').textContent);
    console.log(document.querySelector('#txt-quantity').value);
    const purchase = {
        productName: document.querySelector('#product-name').textContent,
        quantity: document.querySelector('#txt-quantity').value
    }

    fetch(API_Service, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(purchase)
    })
    .then(response => response.json())
    .then(data => {
        const message = 'Thank you for shopping with us. You have successfully purchased ' + data.quantity + ' of the product: ' +  data.productName;
        localStorage.setItem("message", message)
    })
    .catch(error => {
        console.error('Error:', error);
    });
}

//EventListener added to the Buy Now button to make the interaction with the api and proceed with the purchase message in anothe HTML file
const buyButton = document.querySelector('#btn-buy');
buyButton.addEventListener("click", (event) => {
    event.preventDefault();
    buyNow()
    setTimeout(() =>{
        window.location.href = buyButton.href
    }, 2000)
});


