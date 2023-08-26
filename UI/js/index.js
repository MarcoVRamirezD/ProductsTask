class Product {
    constructor(name, code, price, description){
        this.name = name;
        this.code = code;
        this.price = price;
        this.description = description
    }
}



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
        localStorage.setItem("productname",data[3].productName);
        const productName = localStorage.getItem('productname');
        localStorage.setItem("productcode",data[3].productCode);
        const productCode = localStorage.getItem('productcode');
        localStorage.setItem("price",data[3].price);
        const price = localStorage.getItem('price');
        localStorage.setItem("description",data[3].description);
        const description = localStorage.getItem('description');
        const product = new Product(productName, productCode, price, description)
        localStorage.clear();
        includeProductInformation(product.name, product.code, product.price, product.description)
    })
    .catch(error => {
        console.error('Error: ', error);
    });    
}

getProducts()

const includeProductInformation = (nameP, codeP, priceP, descriptionP) =>{
    const productName = document.querySelector('#product-name');
    const productCode = document.querySelector('#product-code');
    const description = document.querySelector('#description');
    const price = document.querySelector('#price');

    productName.textContent = nameP
    productCode.textContent = codeP
    description.textContent = priceP
    price.textContent = descriptionP

    localStorage.setItem("currentProduct", nameP)
}

let currentProduct = localStorage.getItem('currentProduct');
console.log(currentProduct)

