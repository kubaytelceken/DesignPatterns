using RepositoryDesignPattern.Entitites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDesignPattern.DAL.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> ProductListWithCategory();
    }
}
