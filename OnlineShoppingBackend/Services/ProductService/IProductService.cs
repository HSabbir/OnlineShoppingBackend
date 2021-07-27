using OnlineShoppingBackend.Dtos.Product;
using OnlineShoppingBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingBackend.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<GetProductDto>>> GetAllProduct();
        Task<ServiceResponse<GetProductDto>> GetProductById(int id);
        Task<ServiceResponse<List<GetProductDto>>> AddProduct(AddProductDto newProduct);
        Task<ServiceResponse<GetProductDto>> UpdateProduct(UpdateProductDto updatedProduct);
        Task<ServiceResponse<List<GetProductDto>>> DeleteProduct(int id);
    }
}
