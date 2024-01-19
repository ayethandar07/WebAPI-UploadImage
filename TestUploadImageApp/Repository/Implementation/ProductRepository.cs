using TestUploadImageApp.Models.Domain;
using TestUploadImageApp.Repository.Abstract;

namespace TestUploadImageApp.Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _context;

        public ProductRepository(DatabaseContext context)
        {
            _context = context;
        }

        public bool Add(Product model)
        {
            try
            {
                _context.Product.Add(model);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            { 
                return false;
            }
        }
    }
}
