const product = {}

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
        console.log(data)
        console.log(data[3])
        localStorage.setItem("productname",data[3].productName);
        product.productName = localStorage.getItem('productname');
        localStorage.setItem("productcode",data[3].productCode);
        product.productCode = localStorage.getItem('productcode');
        localStorage.setItem("price",data[3].price);
        product.price = localStorage.getItem('price');
        localStorage.setItem("description",data[3].description);
        product.description = localStorage.getItem('description');
    })
    .catch(error => {
        console.error('Error: ', error);
    });    
}

getProducts()

console.log(product);