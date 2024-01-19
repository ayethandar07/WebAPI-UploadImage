using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestUploadImageApp.Models.Domain;
using TestUploadImageApp.Models.DTO;
using TestUploadImageApp.Repository.Abstract;

namespace TestUploadImageApp.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IProductRepository _productRepository;

        public ProductController(IFileService fileService, IProductRepository productRepository)
        {
            this._fileService = fileService;
            this._productRepository = productRepository;
        }

        [HttpPost]
        public IActionResult Add([FromForm] Product model)
        {
            var status = new Status();

            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Please pass the valid data";

                return Ok(status);
            }

            if(model.ImageFile != null)
            {
                var fileResult = _fileService.SaveImage(model.ImageFile);

                if(fileResult.Item1 == 1)
                {
                    model.ProductImage = fileResult.Item2; // getting name of image
                }

                var productResult = _productRepository.Add(model);
                if (productResult)
                {
                    status.StatusCode = 1;
                    status.Message = "Added successfully";
                }
                else
                {
                    status.StatusCode=0;
                    status.Message = "Error on adding product";
                }             

            }

            return Ok(status);
        }
    }
}


//https://localhost:7257/resources/3b5dd542-31c9-4bd3-8650-52b2485a0748.jpg