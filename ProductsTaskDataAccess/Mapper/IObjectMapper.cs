using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsTaskDataAccess.Mapper
{
    public interface IObjectMapper
    {
        // Method to build DTO Objects
        List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows);
        // Method to build a DTO Object
        BaseEntity BuildObject(Dictionary<string, object> row);
    }
}
