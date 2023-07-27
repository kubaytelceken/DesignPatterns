using RepositoryDesignPattern.DAL.Abstract;
using RepositoryDesignPattern.DAL.Concrete;
using RepositoryDesignPattern.DAL.Repositories;
using RepositoryDesignPattern.Entitites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDesignPattern.DAL.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>,ICategoryDal
    {
        public EfCategoryDal(Context context):base (context) 
        {

        }
    }
}
