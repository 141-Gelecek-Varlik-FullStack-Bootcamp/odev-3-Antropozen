using Demo.Model;
using Demo.Service.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }
        
        [HttpGet]
        public General<List<Model.Product.Product>> GetAll()
        {
            return productService.GetAll();
        }
        [HttpPost]
        public General<Model.Product.Product> Insert([FromBody] Model.Product.Product newProduct)
        {
            return productService.Insert(newProduct);
        }
        [HttpPut("{id}")]
        public General<Model.Product.Product> Update(int id, [FromBody] Model.Product.Product updateProduct)
        {
            return productService.Update(id, updateProduct);
        }
        
        [HttpDelete("{id}")]
        public General<Model.Product.Product> Delete(int id)
        {
            return productService.Delete(id);
        }

    }
}
