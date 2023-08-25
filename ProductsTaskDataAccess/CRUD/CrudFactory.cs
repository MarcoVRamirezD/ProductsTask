using DTOs;
using ProductsTaskDataAccess.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsTaskDataAccess.CRUD
{
    public abstract class CrudFactory
    {
        protected SqlDao dao;
        //Definition of the CRUD methods
        public abstract void Create(BaseEntity dto);
        public abstract T Retrieve<T>();
        public abstract List<T> RetrieveAll<T>();
        public abstract void Update(BaseEntity dto);
        public abstract void Delete(BaseEntity dto);

    }
}
