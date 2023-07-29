using Microsoft.EntityFrameworkCore;
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
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        private readonly Context _context;
        public EfProductDal(Context context) : base (context)
        {
            _context = context;
        }

        public List<Product> ProductListWithCategory()
        {
            return _context.Products.Include(x => x.Category).ToList();
        }
    }
}
