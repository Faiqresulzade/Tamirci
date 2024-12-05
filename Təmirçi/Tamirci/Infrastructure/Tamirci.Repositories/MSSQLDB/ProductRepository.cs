using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamirci.Entities;
using Tamirci.Repository.Contracts.MSSQLDB;

namespace Tamirci.Repositories.MSSQLDB
{
    public class ProductRepository : MsSqlDBRepositoryBase<Product>, IProductRepository
    {
      
    }
}
