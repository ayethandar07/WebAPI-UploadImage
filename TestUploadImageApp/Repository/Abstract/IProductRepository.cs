using TestUploadImageApp.Models.Domain;

namespace TestUploadImageApp.Repository.Abstract
{
    public interface IProductRepository
    {
        bool Add(Product model);
    }
}
