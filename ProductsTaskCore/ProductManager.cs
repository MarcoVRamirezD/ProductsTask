using DTOs;
using ProductsTaskDataAccess.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsTaskCore
{
    public class ProductManager
    {
        public string Create(Product product)
        {
            var crud = new ProductCrudFactory();

            crud.Create(product);

            var message = $"The product: {product.productName} with the code: {product.productCode} has been created succesfully!";
            
            return message;
        }

        public List<Product> RetrieveAll() 
        {
            var crud = new ProductCrudFactory();
            var lstResults = crud.RetrieveAll<Product>();

            return lstResults;
        }
    }
}
