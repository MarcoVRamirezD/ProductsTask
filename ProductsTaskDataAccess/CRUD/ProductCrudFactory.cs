using DTOs;
using ProductsTaskDataAccess.DAOs;
using ProductsTaskDataAccess.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsTaskDataAccess.CRUD
{
    public class ProductCrudFactory : CrudFactory
    {

        ProductMapper _mapper;

        //The constructor instance the DAO
        public ProductCrudFactory()
        {
            _mapper = new ProductMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity dto)
        {
            var product = (Product)dto;

            var sqlOperation = _mapper.GetCreateStatement(product);

            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity dto)
        {
            throw new NotImplementedException();
        }

        public override T Retrieve<T>()
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstProducts = new List<T>();

            var sqlOperation = _mapper.GetRetriveAllStatement();

            var lstResults = dao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0) 
            {
                var ObjsProduct = _mapper.BuildObjects(lstResults);

                foreach (var product in ObjsProduct)
                {
                    lstProducts.Add((T)Convert.ChangeType(product, typeof(T)));
                }
            }

            return lstProducts;
        }

        public override void Update(BaseEntity dto)
        {
            throw new NotImplementedException();
        }
    }
}
