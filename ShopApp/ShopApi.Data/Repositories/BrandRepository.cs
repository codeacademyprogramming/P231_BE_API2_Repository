using ShopApp.Core.Entities;
using ShopApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Data.Repositories
{
    public class BrandRepository :Repository<Brand>, IBrandRepository
    {
        private readonly ShopDbContext _context;

        public BrandRepository(ShopDbContext context):base(context) 
        {
            _context = context;
        }
      
    }
}
