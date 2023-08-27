using DTOs;
using ProductsTaskDataAccess.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsTaskDataAccess.Mapper
{
    public class ProductMapper : ISqlStatements, IObjectMapper
    {
        #region "Builders"
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var product = new Product
            {
                productCode = GetStringValue(row, "PRODUCT_CODE"),
                productName = GetStringValue(row, "PRODUCT_NAME"),
                price = GetDoubleValue(row, "PRICE"),
                description = GetStringValue(row, "DESCRIPTION"),
            };

            return product;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var product = BuildObject(row);
                Product newProduct = (Product)product;

                lstResults.Add(newProduct);
            }

            return lstResults;
        }
        #endregion

        #region "Values Getters"
        protected string GetStringValue(Dictionary<string, object> dic, string attName)
        {
            var val = dic[attName];
            if (dic.ContainsKey(attName) && (val is string))
                return (string)dic[attName];

            return null;
        }

        protected double GetDoubleValue(Dictionary<string, object> dic, string attName)
        {
            object val;
            if (dic.TryGetValue(attName, out val) && (val is int || val is double || val is decimal))
                return Convert.ToDouble(val);

            return -1.0;
        }
        #endregion

        #region "SQL Statements"
        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "CRE_PRODUCT_PR" };

            var product = (Product)entity;

            sqlOperation.AddVarcharParam("P_PRODUCT_CODE", product.productCode);
            sqlOperation.AddVarcharParam("P_PRODUCT_NAME", product.productName);
            sqlOperation.AddDecimalParam("P_PRICE", product.price);
            sqlOperation.AddVarcharParam("P_DESCRIPTION", product.description);

            return sqlOperation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var sqlOperation = new SqlOperation { ProcedureName = "RET_ALL_PRODUCT_PR" };

            return sqlOperation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
